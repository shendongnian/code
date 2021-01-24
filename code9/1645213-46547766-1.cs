    class processor
    {
        private User user;
        public processor()
        {
            user = new User();
        }
        private void UseSameVarName()
        {
            int user = 0; //it will not allow you to use `user` as another var name since you already have that name as `User` var
        }
    }
