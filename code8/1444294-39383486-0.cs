        public class Information : ICloneable
        {
           public Tuple<string, string> pair { get; set; }
           public double Signal { get; set; }
           public double SigmaMove { get; set; }
           public DateTime Date { get; set; }
           
           #region ICloneable Members
           public Information Clone() { return new Information(this); }
           object ICloneable.Clone()
           {
              return Clone();
           }
           #endregion
        }
