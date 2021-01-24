    public static class Try
    {
        public static void Action(Action a)
        {
            try
            {
                a();
            }
            catch (Exception e)
            {
                //do whatever you want here
                throw new OtherException(e.Message, e);
            }
        }
    }
