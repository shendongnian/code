        public static JObject GetBook(JObject jObject, string category)
        {
            JObject returnValue = null;
            try
            {
                var array = jObject.Property("store").Value;
                var first = (JObject)array.FirstOrDefault();
                var goods = first?.Property("goods").Value;
                var books = ((JObject)goods).Property("book").Value;
                var booksArray = books as JArray;
                
                foreach (JObject book in booksArray)
                {
                    if (book.Property("category")?.Value?.ToString() == category)
                    {
                        returnValue = book;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return returnValue;
        }
