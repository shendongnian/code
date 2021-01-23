    class MyFormatter : IFormatProvider
        {
            public object GetFormat(Type formatType)
            {
                Console.WriteLine("GetFormat");
                return this;
            }    
        }
