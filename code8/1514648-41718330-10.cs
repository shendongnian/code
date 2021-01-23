    public static class SessionManagement
    {
        static UserEntity sessionUser = null;
    
        public static void LoggedAs(UserEntity user)
        {
            sessionUser = user;
        }
        // other methods/fields to manage session
    }
