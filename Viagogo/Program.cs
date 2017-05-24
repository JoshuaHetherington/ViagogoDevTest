/*
 * Author: Joshua Hetherington
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Viagogo
{
	class Program
	{
		public static void Main(string[] args)
		{
            bool validInput = false;
            string userInput;
            string[] user = null;

            //loop for validating user input
            while (!validInput)
            {
                Console.WriteLine("Please Input Coordinates in the format x,y :");

                userInput = "";
                //will loop until user input is not an empty string
                while (userInput == "")
                {
                    userInput = Console.ReadLine();
                }

                //Pattern for regex to check input with
                string pattern = @"(-{0,1})(\d+),(-{0,1})(\d+)";
                Regex reg = new Regex(pattern);
                Match m = reg.Match(userInput);
                if (m.Success)
                {
                    user = userInput.Split(',');

                    if (user == null)
                    {
                        Console.WriteLine("Error!");
                    }
                    else
                    {
                        int x = Int32.Parse(user[0]);
                        int y = Int32.Parse(user[1]);

                        if (x < -10 || x > 10 || y < -10 || y > 10)
                        {
                            Console.WriteLine("Error! The correct range is e.g. x-axis -10 to +10, y-axis -10, +10.");
                        }
                        else
                        {
                            validInput = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error! Incorrect syntax! Please ensure there are no unecessary characters or spaces. e.g. 3,-10");
                }
            }
            //Method to generate seed data
            List<Location> locations = GenerateData();

            //output to be displayed
            List<string> output = GetOutput(user, locations);
            
            foreach(string s in output)
            {
                Console.WriteLine(s);
            }

            //Pausing the console application 
            Console.ReadLine();
        }

        //Method to generate seed data
		public static List<Location> GenerateData()
		{
            //generate locations (-10 to +10 x-axis, -10 to +10 y-axis)
            int x, y, numOfTickets;
            Random rand = new Random();
            List<Location> locations = new List<Location>();
            Location tempLocation;
            Event tempEvent;
            bool duplicate = true;

            for (int i = 0; i < 12; i++)
            {
                //Create Events, Each event will create a random number of tickets between 0 - 100 
                numOfTickets = rand.Next(0, 101);
                tempEvent = new Event(i + 1, numOfTickets);

                //Create locations, will stay in while loop if duplicate locations are generated
                while (duplicate)
                {
                    x = rand.Next(-10, 11);
                    y = rand.Next(-10, 11);
                    tempLocation = new Location(x, y, tempEvent);

                    if (!CheckForDuplicateLocation(tempLocation, locations))
                    {
                        locations.Add(tempLocation);
                        duplicate = false;
                    }
                    
                }
                duplicate = true;
            }

            return locations;

		}

        //Method to check for duplicate locations in the list of locations
        public static bool CheckForDuplicateLocation(Location tempLocation, List<Location> locations)
        {
            foreach(Location l in locations)
            {
                //uses Location's method to check if the locations are the same (x and y values equal)
                if(l.CompareLocations(tempLocation.GetX(), tempLocation.GetY()))
                {
                    return true;
                }
            }
            return false;
        }

        //Method to sort the lists and format the output
        public static List<string> GetOutput(string[] userInput, List<Location> locations)
        {
            List<string> output = new List<string>();
            //Method to get the distance from user to event
            int x = Int32.Parse(userInput[0]);
            int y = Int32.Parse(userInput[1]);

            Console.WriteLine("\nClosest Events to (" + x + "," + y + "):\n\n");

            //this will loop through the list of locations and set a Manhattan distance from the user and the location
            foreach (Location l in locations)
            {
                l.SetDistanceFromUser(x, y);
            }

            //Uses Linq to sort the List by the Manhattan distance and orders them into a new List
            List<Location> SortedByDistanceEvents = locations.OrderBy(l=>l.distanceFromUser).ToList();

            //Method to order the list of tickets at each event by the cheapest price using the sorted locations list
            foreach (Location l in SortedByDistanceEvents)
            {
                l.GetCurrentEvent().SetTickets(l.GetCurrentEvent().GetTickets().OrderBy(t => t.price).ToList());
            }

            string str = "";

            //Loops through the top 5 closests events and creates a list of strings for the output
            for(int i = 0; i < 5; i ++)
            {
                str = "Event " + SortedByDistanceEvents[i].GetCurrentEvent().GetEventID() + " - $" + SortedByDistanceEvents[i].GetCurrentEvent().GetTickets().First().price.ToString("F") + 
                    ", Distance " + SortedByDistanceEvents[i].GetDistanceFromUser();
                output.Add(str);
            }

            return output;
        }
    }
}
