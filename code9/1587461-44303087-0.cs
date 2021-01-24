        var userInfo = new UserInfoModel();
        // write the data (overwrites)
        using (var stream = new StreamWriter(@"path/to/your/file.json", append: false))
        {
            stream.Write(JsonConvert.SerializeObject(userInfo));   
        }
        //read the data
        using (var stream = new StreamReader(@"path/to/your/file.json"))
        {
            userInfo = JsonConvert.DeserializeObject<UserInfoModel>(stream.ReadToEnd());
        }
        public class UserInfoModel
        {
             public DateTime Date { get; set; }
            // etc.
        }
