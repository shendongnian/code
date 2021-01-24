    public static string GetBrandByImage(string imageType) {
        using(var obj = new BrandsDBEntities()) {    
            var name = (from g in obj.guitarBrands 
                        where g.image == imageType 
                        select g.name).FirstOrDefault();
    
            return name;
        }
    }
