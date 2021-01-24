    public class Class1
    {
        public static void Main(string[] args)
        {
            Ticket ticket = new Ticket();
            ticket.Id = 1;
            ticket.Fullname = "Test1";
            ticket.Fullprice = true;
            Ticket ticket1 = new Ticket();
            ticket1.Id = 2;
            ticket1.Fullname = "Test2";
            ticket1.Fullprice = false;
            Ticket ticket2 = new Ticket();
            ticket2.Id = 3;
            ticket2.Fullname = "Test3";
            ticket2.Fullprice = true;
            Ticket ticket3 = new Ticket();
            ticket3.Id = 4;
            ticket3.Fullname = "Test4";
            ticket3.Fullprice = true;
            Ticket ticket4 = new Ticket();
            ticket4.Id = 5;
            ticket4.Fullname = "Test5";
            ticket4.Fullprice = false;
            Ticket ticket5 = new Ticket();
            ticket5.Id = 6;
            ticket5.Fullname = "Test6";
            ticket5.Fullprice = true;
            List<Ticket> tickets = new List<Ticket>();
            tickets.Add(ticket);
            tickets.Add(ticket1);
            tickets.Add(ticket2);
            tickets.Add(ticket3);
            tickets.Add(ticket4);
            tickets.Add(ticket5);
            var result = tickets.Where(t => t.Fullprice == true);
            int Count = 0;
            foreach (var noofpeople in result)
            {
                Count++;
            }
            Console.WriteLine(Count*5.50);
            Console.ReadLine();
        }
    }
