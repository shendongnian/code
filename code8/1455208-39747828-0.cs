    public static WPSitems MapObjectWithIdenticalProperties<T>(T itemOfUnknownType) where T : new() 
        {
            var inputType = typeof(T);
            var outputType = typeof(WPSitems);
                var outputItem = new WPSitems();
                foreach (var inputProperty in inputType.GetProperties())
                {
                    var matchingOutputProperty = outputType.GetProperties().FirstOrDefault(x => x.Name == inputProperty.Name);
                    if(matchingOutputProperty != null)
                        matchingOutputProperty.SetValue(outputItem, inputProperty.GetValue(itemOfUnknownType));
                }
            return outputItem;
        }
