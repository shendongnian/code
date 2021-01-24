            MyInheritedClass (MyClass baseObject)
             {      
               //Get the list of properties available in base class
                var properties = baseObject.GetProperties();
            
                properties.ToList().ForEach(property =>
                {
                  //Check whether that property is present in derived class
                    var isPresent = this.GetType().GetProperty(property);
                    if (isPresent != null)
                    {
                        //If present get the value and map it
                        var value = baseObject.GetType().GetProperty(property).GetValue(baseObject, null);
                        this.GetType().GetProperty(property).SetValue(this, value, null);
                    }
                });
             }
