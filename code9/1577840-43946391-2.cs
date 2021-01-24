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
                //It's not a good practice to keep only the error message (you may need other exception details later)
                throw new clsException(string.Format("{0}: {1}", sMethodName, ex.Message));
            }
        }
