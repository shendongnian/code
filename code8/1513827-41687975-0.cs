    public class Profile1 : Profile 
    {
        public Profile1(){ //... for version < 5, use protected void Configure
             CreateMap<SKU, SKUModel>()
             //........
        }
    }
