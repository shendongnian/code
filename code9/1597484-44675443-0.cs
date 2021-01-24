        public void SendNewUser(User user)
        {
            if (user is DerivedUser)
            {
                SendNewUserInternal((DerivedUser)user);
            }
            else if (user is OtherDerivedUser)
            {
                SendNewUserInternal((OtherDerivedUser)user);
            }
        }
