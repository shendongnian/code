    private class PasswordFinder : IPasswordFinder
    {
        private string password;
        public PasswordFinder(string password)
        {
            this.password = password;
        }
        public char[] GetPassword()
        {
            return password.ToCharArray();
        }
    }
