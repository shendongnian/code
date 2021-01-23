        public class Information : ICloneable
        {
           public Tuple<string, string> pair { get; set; }
           public double Signal { get; set; }
           public double SigmaMove { get; set; }
           public DateTime Date { get; set; }
           public Information(Information Tem)
           {
              pair = Tem.pair;
              Signal  = Tem.Signal ;
              SigmaMove = Tem.SigmaMove;
              Date = Tem.Date;
           }           
           #region ICloneable Members
           public Information Clone() { return new Information(this); }
           object ICloneable.Clone()
           {
              return Clone();
           }
           #endregion
        }
