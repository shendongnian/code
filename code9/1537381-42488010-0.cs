        public class Element : ElementBase
        {
          protected string type;
          public virtual List<ElementBase> elements { get; set;}
          public List<ElementBase> Elements
          {
              get { return this.elements; }
          }
        }
