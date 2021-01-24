    using Newtonsoft.Json;
    public class MainActivity : Activity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            BlobCache.ApplicationName = "AkavacheText";
            string json = @"{ 'Username': 'Mike','Password': 'Ma'}"; 
            SetContentView(Resource.Layout.Main);
            var getData = JsonConvert.DeserializeObject<User>(json);
            System.Console.WriteLine(getData.Username+"---"+ getData.Password);
        }
     }
    public class User
    {
      public  string Username { get; set; }
      public string   Password { get; set; }
    }
