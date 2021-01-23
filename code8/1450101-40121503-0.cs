        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                 (...)
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
