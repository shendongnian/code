    T control = FindPageObjects
                .SelectMany
                    (
                        pageObject => 
                        pageObject.PropertyType.GetFields()
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
                        selectedControl =>
                        selectedControl.FieldType
                        .GetConstructor(new[] { typeof(IWebDriver), typeof(By)})
                        .Invoke
                            (
                                new object[]
                                {
                                    driver, 
                                   ((FindsByAttribute)(selectedControl.GetCustomAttribute(typeof(FindsByAttribute)))).Locator
                                }
                            )
                    )
                .OfType<T>()
                .FirstOrDefault();
