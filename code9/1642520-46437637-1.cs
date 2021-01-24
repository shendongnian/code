    T control = FindPageObjects
                .SelectMany
                    (
                        pageObject => 
                        pageObject.PropertyType.GetFields())
                    )
                .Where
                    (
                        control =>
                        control.FieldType == typeof(T) && 
                        control.Name == fieldNameNoSpaces
                    )
                .Select
                    (    
                        control =>
                        ((T)control).FieldType
                        .GetConstructor(new[] { typeof(IWebDriver), typeof(By)})
                        .Invoke(new object[] {driver, (FindsByAttribute)control.GetCustomAttribute(typeof(FindsByAttribute).Locator})
                    )
                .FirstOrDefault();
