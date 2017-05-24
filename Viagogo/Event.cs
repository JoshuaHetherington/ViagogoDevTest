/*
 * Author: Joshua Hetherington
 */
using System;
using System.Collections.Generic;

namespace Viagogo
{
	class Event
	{
		private int eventID;
		private int numberOfTickets;
		private List<Ticket> tickets = new List<Ticket>();

		//Constructors

        public Event()
        {

        }

		public Event(int eventID, int numberOfTickets)
		{
			this.eventID = eventID;
			this.numberOfTickets = numberOfTickets;
            GenerateTickets();
		}

		//Accessors

		public int GetEventID()
		{
			return this.eventID;
		}

		public int GetNumberOfTickets()
		{
			return this.numberOfTickets;
		}

		public List<Ticket> GetTickets()
		{
			return this.tickets;
		}

        //Mutators

        public void SetTickets(List<Ticket> tickets)
        {
            this.tickets = tickets;
        }
		
        //Other Methods

        private void GenerateTickets()
        {
            Ticket tempTicket;
            double price;
            Random rand = new Random();

            for (int i = 0; i < this.numberOfTickets; i++)
            {
                price = rand.NextDouble() * 200.00;
                tempTicket = new Ticket(price);
                this.tickets.Add(tempTicket);
            }
        }
	}
}
