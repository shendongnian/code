    public static IList<T> SelectAll<T>() where T : class
            {
                try
                {
                    using (NWindDataContext context = new NWindDataContext())
                    {
                        // get the table matching the type
                        // and return all of it as typed list
                        var table = context.GetTable<T>().ToList<T>();
                        return table;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
