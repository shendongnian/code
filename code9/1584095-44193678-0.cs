    private async Task UpdateNavProperties(T original, T newObject)
        {
            await Task.Run(async () =>
            {
                //get type of object
                var objType = original.GetType();
                //loop through properties on the Type
                foreach (var prop in objType.GetProperties())
                {
                    //Check that property is a class/reference type, and not part of the System namespace
                    //string would be part of the system namespace, but my custom class not
                    if (prop.PropertyType.IsClass && !prop.PropertyType.Namespace.Equals("System"))
                    {
                        //get the old value
                        var oldValue = prop.GetValue(original);
                        //get new value
                        var newValue = newObject.GetType().GetProperty(prop.Name).GetValue(newObject);
                        //update the value 
                        _context.Entry(oldValue).CurrentValues.SetValues(newValue);
                        //save changes
                        await _context.SaveChangesAsync();
                    }
                }
            });
        }
