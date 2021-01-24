    using System;
    using System.Collections.Generic;
    using System.Linq;
    [Serializable]
    public class Profile
    {
        [NonSerialized]
        public string profileKey;
        [NonSerialized]
        public long utcCreatedTimestamp;
        [NonSerialized]
        public DateTime utcCreated;
        // Serializable attributes
        public string userId;
        public string name;
        public int age;
        public string gender; // "M" or "F"
        public Profile() { }
        public Profile(Dictionary<string, object> fromFirebaseResult)
        {
            userId = fromFirebaseResult.ContainsKey("userId") ? fromFirebaseResult.First(x => x.Key == "userId").Value.ToString() : string.Empty;
            name = fromFirebaseResult.ContainsKey("name") ? fromFirebaseResult.First(x => x.Key == "name").Value.ToString() : string.Empty;
            age = fromFirebaseResult.ContainsKey("age") ? int.Parse(fromFirebaseResult.First(x => x.Key == "age").Value.ToString()) : 0;
            gender = fromFirebaseResult.ContainsKey("gender") ? fromFirebaseResult.First(x => x.Key == "gender").Value.ToString() : string.Empty;
            if (fromFirebaseResult.ContainsKey("utcCreatedUnix")) {
                long milliseconds;
                if(long.TryParse(fromFirebaseResult.First(x => x.Key == "utcCreatedUnix").Value.ToString(), out milliseconds)) {
                    utcCreatedTimestamp = milliseconds;
		    		DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		    		utcCreated = epoch.AddMilliseconds(milliseconds);
                }
            }
        }
    }
