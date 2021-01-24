    T control = FindPageObjects
                .SelectMany
                    (
                        pageObject => 
                        pageObject.PropertyType.GetFields())
                    )
                .OfType<T>()
                .Where
                    (
                        control =>
                        control.FieldType == typeof(T) && 
                        control.Name == fieldNameNoSpaces
                    )
                .Select
                    (    
                        control =>
                        control.FieldType
                        .GetConstructor(new[] { typeof(IWebDriver), typeof(By)})
                        .Invoke(new object[] {driver, (FindsByAttribute)control.GetCustomAttribute(typeof(FindsByAttribute).Locator})
                    )
                .OfType<T>()
                .FirstOrDefault();
