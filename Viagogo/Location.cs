/*
 * Author: Joshua Hetherington
 */
using System;

namespace Viagogo
{
	class Location
	{
		//Data Fields

		private int x;
		private int y;
		private Event currentEvent;
		public int distanceFromUser;

		//Constructors

        public Location()
        {

        }

		public Location(int x, int y, Event currentEvent)
		{
			this.x = x;
			this.y = y;
			this.currentEvent = currentEvent;
		}

		//Accessors

		public int GetX()
		{
			return this.x;
		}

		public int GetY()
		{
			return this.y;
		}

		public Event GetCurrentEvent()
		{
			return this.currentEvent;
		}

        public int GetDistanceFromUser()
        {
            return this.distanceFromUser;
        }

		//Mutators

		public void SetDistanceFromUser(int x, int y)
		{
			distanceFromUser = GetManhattanDistance(x, y);
		}

        //Other Methods

		private int GetManhattanDistance(int x, int y)
		{
			int distance = Math.Abs(this.x - x) + Math.Abs(this.y - y);
			return distance;
		}

        public bool CompareLocations(int x, int y)
        {
            if (this.x == x && this.y == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

	}
}
