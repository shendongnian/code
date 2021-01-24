    private static string GetCurrentMethodName()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);
            return sf.GetMethod().Name;
        }
