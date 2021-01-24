        public static string ReturnString(string sa, string sb)
        {
            try
            {
                //...
                //...
                return "xyz";
            }
            catch (Exception ex)
            {
                StackTrace oStackTrace = new StackTrace();
                string sMethodName = oStackTrace.GetFrame(1).GetMethod().Name;
                //Notice that you lose a lot of exception info by copying only the error message.
                throw new clsException(string.Format("{0}: {1}", sMethodName, ex.Message));
            }
        }
