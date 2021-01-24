    void Main()
    {
    	var ticketsList = new List<Ticket>();
    	ticketsList.Add(new Ticket { pk = 1, owner="John", reffering="Sam"  , created_time = new DateTime(2017, 11, 15, 11, 33, 20) });
    	ticketsList.Add(new Ticket { pk = 2, owner="John", reffering="Sam"  , created_time = new DateTime(2017, 11, 15, 11, 33, 21) });
    	ticketsList.Add(new Ticket { pk = 3, owner="Pat" , reffering="Jerry", created_time = new DateTime(2017, 11, 15, 11, 33, 27) });
    	ticketsList.Add(new Ticket { pk = 4, owner="John", reffering="Sam"  , created_time = new DateTime(2017, 11, 15, 11, 33, 28) });
    	ticketsList.Add(new Ticket { pk = 6, owner="Pat" , reffering="Jerry", created_time = new DateTime(2017, 11, 15, 11, 33, 35) });
    	ticketsList.Add(new Ticket { pk = 5, owner="John", reffering="Sam"  , created_time = new DateTime(2017, 11, 15, 11, 34, 00) });
    	
    	var now = DateTime.Now;
    	
    	var orderedList = ticketsList.OrderBy(p => p.created_time).GroupBy(p => new { p.owner, p.reffering }).Select(g => g.ToList());
    	
        // Here is the 10 seconds grouping. I'm basically creating a new date 
        // starting at the beginning of a 10 seconds interval. I will then 
        // use this new date to perform the grouping.
    	var normalizedGroupKeysList = ticketsList.Select(t => new { ticket = t, groupKey = t.created_time.HasValue ? t.created_time.Value.AddSeconds(-t.created_time.Value.Second % 10) : now });
    	
    	var result = normalizedGroupKeysList.GroupBy(t => t.groupKey, t => t.ticket);
    }
    
    public class Ticket
    {
        public int pk { get; set; }
    	public string owner { get; set; }
        public string reffering { get; set; }
    
        public DateTime? created_time { get; set; }
    }
