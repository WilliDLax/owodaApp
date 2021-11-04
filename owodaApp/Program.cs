using System;

namespace owodaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Owoda musa = new Owoda();
            musa.ChooseOperation();
        }
    }


    class Owoda
    {
        public string UserOperation { get; set; }
        public string TicketChoice { get; set; }

        public int DailyTicketsSold = 0;
        public double totalPriceSold = 0.00;
        public double TicketPriceDefault = 100;

        public double GetMonthlyTicketPrice(double ticketPrice)
        {
            return (ticketPrice / 2) * 30;
        }

        public void ChooseOperation()
        {
            Console.WriteLine("Choose an operation: \n1. Sell ticket \n2. Check daily summary");
            int answerIndex = int.Parse(Console.ReadLine());

            while(answerIndex == 1)
            {
                SellTicket();
                Console.WriteLine("Choose an operation: \n1. Sell ticket \n2. Check daily summary");
                answerIndex = int.Parse(Console.ReadLine());

                DailyTicketsSold++;
            }
            calculateProfit();
        }

        public void SellTicket()
        {
            Random ticketId = new Random();

            double ticketPrice;
            Console.WriteLine("Choose a ticket type: \n1. Daily \n2.Monthly");
            int answerIndex = int.Parse(Console.ReadLine());
            if(answerIndex == 1)
            {
                ticketPrice = TicketPriceDefault;
            }
            else
            {
                ticketPrice = GetMonthlyTicketPrice(TicketPriceDefault);
            }
            totalPriceSold += ticketPrice;

            Console.WriteLine("Ticket Sold succesfully! \nYour id is " + ticketId.Next(10));
        }

        public void calculateProfit()
        {
            Console.WriteLine("You sold " + DailyTicketsSold + " tickets today");

            double total = totalPriceSold;
            Console.WriteLine("Total money you made today is " + total);

            double profit = total - (0.65 * total);
            Console.WriteLine("Your profit after paying chairman is " + profit);
        }

    }
}
