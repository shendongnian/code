        static void Main(string[] args)
        {
            try
            {
                using (var disp = new MyDisposable())
                {
                    throw new Exception("Boom");
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
