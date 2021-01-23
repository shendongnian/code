    public Guid Save<T>(T obj) where T : ISomeInterface
        {
            Guid newId = Guid.NewGuid();
            try
            {
                foreach (MethodInfo method in (typeof(T)).GetMethods())
                {
                    if (IsXmlElement(method))
                    {
                        // A way to get this method's value
                        // e.g. if T has method GetName, and GetName was assigned 'John' 
                        //i.e. object.GetName = 'John'Is there a way to get 'John' from this GetName method?
                    }
                }
