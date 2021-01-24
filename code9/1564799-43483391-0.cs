     public static class Get
    {
        public static class Question
        {
            public static string byId()
            {
                Func<OracleConnection, string> func1 = (co) => co.ToString();
                return Do<string>(func1);
            }
        }
    }
     public static type Do<type>(Func<OracleConnection, type> fun)
        {
            OracleConnection co = null;
            type ret = default(type);
            try
            {
                co = CreateCo();
                MessageBox.Show("Connected");
                ret = fun(co);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            finally
            {
                CloseCo(co);
            }
            return ret;
        }
