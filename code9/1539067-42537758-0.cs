            try
            {
                Man p = new Man("Dan");
            }
            catch (NameNotValidException e)
            {
                Console.WriteLine("Please Write a valid name! " + e.Message);
            }
