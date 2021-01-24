       public T Common<T>(Func<T> action)
        {
            //do something log or watch
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }
        public Int32 Run(string query)
        {
            //Set whatever type you want. Or extend generic parameters
            return Common<Int32>(() =>
            {
                return 1;
            });
        }
