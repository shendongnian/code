     List<Product> prodata = new List<Product>();
           RootObject _rootObject = new RootObject();
            var list = db.productGetData().ToList();
             
            foreach (var listdata in list)
            {
               var _listOfProperties = new List<Property>();
               //if product list contains data of properties
               foreach(var _prop in listdata.Properies)
               {
                  var property = new Property();
                  property.PropertyKey = _prop.PropertyKey;
                  property.PropertyValue = _prop.PropertyValue;
                  _listOfProperties.Add(property);
               }
               
                Product pdata = new Product();
                pdata.Properties = _listOfProperties;
                prodata.Add(pdata);
            }
    _rootObject.Products = prodata;
    
    and now serialize it
    
    string stringData = JsonConvert.SerializeObject(_rootObject);
