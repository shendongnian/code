    public class myProduct
    {
        public int Quantity {get; set;}
        public int Name     {get; set;}
        public double Price {get; set;}
        
        public myProduct(string name)
        { 
          this.Quantity = 1; this.Name = name; this.Price = 0;
        }
        public override string ToString()
        {
          return this.Quantity.ToString() + "-" + this.Name + "-" + 
                 (this.Price * this.Quantity).ToString(c, 
                 CultureInfo.CurrentCulture);
        }
    }
    
