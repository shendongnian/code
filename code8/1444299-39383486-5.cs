        public class Information
        {
          public Tuple<string, string> pair { get; set; }
          public double Signal { get; set; }
          public double SigmaMove { get; set; }
          public DateTime Date { get; set; }
    
          public Information()
          {}
    
          public Information(Information Tem)
          {
            pair = Tem.pair;
            Signal  = Tem.Signal ;
            SigmaMove = Tem.SigmaMove;
            Date = Tem.Date;
          }
        }
