        public static void StoreUser()
        {
            if ( UserExists( "username" ) )
            {
                return;
            }
            //Storing user code
        }
        public static bool UserExists(string userName)
        {
            if (userName == "EXISTS")
            {
                //Show error
                return true;
            }
            return false;
        }
