    public class ProductViewModel {
    
        public string Name{
          get
          {
             return this.Name;
          }
          set{
               this.Name = value;
               this.OutputImage  = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(value))
          }
        }
    }
