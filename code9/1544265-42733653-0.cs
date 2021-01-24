    public struct Customer
    {
       string Link;
       DateTime? LinkStart;
       DateTime? LinkEnd;
      
       public Customer(string link, DateTime? linkStart, DateTime? linkEnd)
       {
           this.Link = link
           this.LinkStart = linkStart;
           this.LinkEnd = linkEnd;
       }
    }
