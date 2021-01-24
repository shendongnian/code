    class processor
    {
        private User user; //global var
        public processor()
        {
            user = new User();
        }
        private void CheckUser()
        {
            User user = new User(); //If you declared user as global var it will not allow you to use same name (user) again but if you haven't done that it will allow you to use that name even if you used same var name in another void
        }
        private void SetUser()
        {
            User user = new User(); //If you declared user as global var it will not allow you to use same name (user) again but if you haven't done that it will allow you to use that name even if you used same var name in another void
        }
    }
