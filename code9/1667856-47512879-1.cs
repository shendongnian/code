    public class C
    {
        public void M()
        {
            Connection connection = new Connection();
            try
            {
            }
            finally
            {
                if (connection != null)
                {
                    ((IDisposable)connection).Dispose();
                }
            }
        }
    }
