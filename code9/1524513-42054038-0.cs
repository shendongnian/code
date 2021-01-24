    public class Vector
    {
        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="toCopy">
        /// The vector object to copy
        /// </param>
        public Vector(Vector toCopy)
        {
            if (toCopy == null)
            {
                throw new ArgumentNullException("toCopy");
            }
    
            x = toCopy.x;
            y = toCopy.y;
            //What ever other properties you have, assign them here
        }
    }
