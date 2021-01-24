     var keySubType = bindingContext.ModelName.ToString() + ".";
                
                string subtypeName = bindingContext.ValueProvider.GetValue(keySubType).AttemptedValue;
                
                Type instantiationType = null;
                switch (subtypeName)
                {
                    case "ProductAH":
                        instantiationType = typeof(ProductAH );
                        break;
                    case "ProductAF":
                        instantiationType = typeof(ProductAF );
                        break;
                    case "ProductBC":
                        instantiationType = typeof(ProductBC );
                        break;
                    case "ProductBD":
                        instantiationType = typeof(ProductBD );
                        break;
                }
                //Create an instance of the specified type
                var obj = Activator.CreateInstance(instantiationType);
