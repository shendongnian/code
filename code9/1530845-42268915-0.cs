    public class Rebar : Reinforement
    {
        public new RebarShape Shape
        {
            get { return (RebarShape)base.Shape; }
            set { base.Shape = value; }
        }
    }
