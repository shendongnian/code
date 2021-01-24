        public class Model
        {
            public string pageName { get; set; }
            public List<Ads> ads { get; set; }
    
            public Model clone()
            {
                return (Model)this.MemberwiseClone();
            }
        }
        //after clone any changes to object2 will not reflect to object1
        Model object2 = object1.clone(); 
