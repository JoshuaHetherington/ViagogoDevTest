/*
 * Author: Joshua Hetherington
 */
namespace Viagogo
{
	class Ticket
	{
		//Price (US Dollars)
		public double price;

		//Constructors

        public Ticket()
        {

        }

		public Ticket(double price)
		{
			this.price = price;
		}

		//Accessors

		public double GetPrice()
		{
			return this.price;
		}

		//Mutator

		public void SetPrice(double price)
		{
			this.price = price;
		}
	}
}
