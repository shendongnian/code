        private string GetUserName(string userId,string anotherParameter)
        {
            return CacheIt<string>(() => GetUserNameFromDb(userId, anotherParameter), new { userId,anotherParameter });
        }
        private string GetUserNameFromDb(string userId, string anotherParameter)
        {
            return "FirstName LastName";
        }
