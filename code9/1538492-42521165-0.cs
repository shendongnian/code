    static void Main(string[] args)
        {
            try
            {
                Helper.Do(() => {
                    int x = 1;
                    x++;
                    x = x / 0;
                    x--;
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
    }
e.Message = "Attempted divide by zero"
