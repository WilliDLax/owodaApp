using System;
namespace owodaApp
{
    public class Owoda
    {
        public string UserOperation { get; set; }
        public string TicketChoice { get; set; }

        public int DailyTicketsSold = 0;
        public double totalPriceSold = 0.00;
        public double TicketPriceDefault = 100;

        //caculate price for monthly tickets
        public double GetMonthlyTicketPrice(double ticketPrice)
        {
            return (ticketPrice / 2) * 30;
        }

        //choose whether to sell a ticket or check your summary 
        public void ChooseOperation()
        {
            Console.WriteLine("Choose an operation: \n1. Sell ticket \n2. Check daily summary");
            int answerIndex = int.Parse(Console.ReadLine());
            Console.Clear();

            while (answerIndex == 1)
            {
                SellTicket();
                Console.WriteLine("Choose an operation: \n1. Sell ticket \n2. Check daily summary");
                answerIndex = int.Parse(Console.ReadLine());
                Console.Clear();


                DailyTicketsSold++;
            }
            calculateProfit();
        }

        //sell the ticket
        public void SellTicket()
        {
            double ticketPrice;
            Console.WriteLine("Choose a ticket type: \n1. Daily \n2. Monthly");
            int answerIndex = int.Parse(Console.ReadLine());
            Console.Clear();


            if (answerIndex == 1)
            {
                ticketPrice = TicketPriceDefault;
                TicketChoice = "daily";
            }
            else
            {
                ticketPrice = GetMonthlyTicketPrice(TicketPriceDefault);
                TicketChoice = "monthly";
            }
            totalPriceSold += ticketPrice;

            ShowReceipt();
        }

        //calculate earnings
        public void calculateProfit()
        {
            if (DailyTicketsSold == 0)
            {
                Console.WriteLine("You haven't sold any ticket today. Gerrout!");
            }
            else
            {
                Console.WriteLine("You sold " + DailyTicketsSold + " ticket(s) today");

                double total = totalPriceSold;
                Console.WriteLine("Total money you made today is " + total);

                double chairmanShare = 0.65 * total;
                Console.WriteLine("You will pay chairman " + chairmanShare);

                double profit = total - chairmanShare;
                Console.WriteLine("Your profit after paying chairman is " + profit);
            }
        }


        //Methods to generate a receipt

        public double getTicketPrice(string ticketType)
        {
            if (ticketType == "daily")
            {
                return TicketPriceDefault;
            }
            else
            {
                return GetMonthlyTicketPrice(TicketPriceDefault);
            }
        }

        public void ShowReceipt()
        {
            Random ticketId = new Random();
            Console.WriteLine("Ticket sold!");
            Console.WriteLine("Type:     " + TicketChoice);
            Console.WriteLine("Cost:     " + getTicketPrice(TicketChoice));
            Console.WriteLine("Numb:     " + ticketId.Next(0, 999999).ToString("D13"));
            Console.WriteLine("Sold on:        " + DateTime.Now.ToString("MM/dd/yyyy H:mm"));
            Console.WriteLine("-----------------------------------------------");

        }
    }
}
