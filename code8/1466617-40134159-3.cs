    public class Result
        {
            public string Property1 { get; set; } 
            public int Property2 { get; set; }
    
            //directly in the instatation of the object
            public Result()
            {
                this.Property1 = "a";
                this.Property2 = 1;
            }
    
            //or explicitely within a method
            public void ChangeValues()
            {
                this.Property1 = "a";
                this.Property2 = 1;
            }
            //or explicitely setting the values from outside as parameters
            public void ChangeValues(string property1, int property2)
            {
                this.Property1 = property1;
                this.Property2 = property2;
            }
        }
