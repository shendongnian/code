        /// <summary>
        /// This sets up the recursive function
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetInnerException(Exception e)
        {
            string innerExceptionMessage = "";
            string error = GetInnerException(e, out innerExceptionMessage);
            return error;
        }
    /// <summary>
        /// This is a recursive function which recursively drills down and gets the error.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private static string GetInnerException(Exception e, out string msg)
        {
            if (e.InnerException != null)
                GetInnerException(e.InnerException, out msg);
            else
                msg = e.Message;
            return msg;
        }
