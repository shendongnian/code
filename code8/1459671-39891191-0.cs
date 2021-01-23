        public void MainMethod()
        {
            try
            {
                var myList = SomeMethod();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); // prints out "SomeMethod failed."
            }
        }
        public List<object> SomeMethod()
        {
            try
            {
                int i = 1 + 1;
                // Some process that may throw an exception
                List<object> list = new List<object>();
                list.Add(1);
                list.Add(i);
                return list;
            }
            catch(Exception ex)
            {
                Exception newEx = new Exception("SomeMethod failed.");
                throw newEx;
            }
        }
