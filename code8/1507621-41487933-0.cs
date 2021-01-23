        //This function could be in a public static class
        public static bool AuthorizeExecution(EventHandler method)
        {
            bool autorized = YourDataBaseQuery(UserRole, method.Method.Name);
            return autorized;
        }
        //////////////////////////////
        public static void DownloadFile_ServerClick(object sender, EventArgs e)
        {
            if(!AuthorizeExecution(DownloadFile_ServerClick))
                return;
        }
