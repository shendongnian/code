    public class CarsBase
    {
        public string DisplayName 
        { 
            get 
            { 
                return this.GetType().Name; 
            }
        }
    }
