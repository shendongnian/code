    public class Shape
    {
        public virtual Texture texture { get; set; }
    }
    public class SpecificShape : Shape
    {
        public SpecificTexture specificTexture { get; set; }
        public override Texture texture
        {
            get { return specificTexture; }
            set
            {
                if (value is SpecificTexture specificValue) //this is the only place we have to have a cast
                {
                    specificTexture = specificValue;
                }
                else
                {
                    //handle error, throw exception, Debug.Assert, or something
                }
            }
        }
        
        public SpecificShape()
        {
            specificTexture = new SpecificTexture();
        }
    }
