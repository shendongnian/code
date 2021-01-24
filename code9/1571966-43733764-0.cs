    foreach (var groupedElement in ArraysGrouped)
                {
                    Type typeOfArray = groupedElement.FirstOrDefault().Property.Type; //wyciągamy typ z pierwszego elementu tablicy - bo w tablicy będą elementy tego samego typu
                    int arraySize = groupedElement.Count();
                    dynamic newArray = Array.CreateInstance(typeOfArray, arraySize);
                    
                    foreach (var element in groupedElement)
                    {
                        var newInstance = Activator.CreateInstance(element.Property.Type);
                        
                        newInstance = element.Property.Value;
                        //var value = Convert.ChangeType(newInstance, element.Property.Type);
                        newArray.SetValue(Convert.ChangeType(newInstance, element.Property.Type), element.Index);
                    }
                }
