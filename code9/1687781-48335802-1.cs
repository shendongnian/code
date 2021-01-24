        static void Main(string[] args)
        {
            NameProp np = new NameProp();
            try
            {
                np.firstname = "<>JJ";
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
