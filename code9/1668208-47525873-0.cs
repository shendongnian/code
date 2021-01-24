    public class CountOnlineUserModel : IEquatable<CountOnlineUserModel> {
        // ...
        public bool Equals(CountOnlineUserModel other) {
            return UserUniqueID == other.UserUniqueID;
            // use the above if you just want to compare the IDs. Use below if you want to compare both the ID and name
            return UserUniqueID == other.UserUniqueID && 
                Username == other.Username;
        }
    }
