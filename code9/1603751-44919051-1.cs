    namespace WorkApp
    {
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class TestPage : ContentPage
        {
            private string Uri = "http://192.168.0.124:59547/api/";
            List<Machine> machines;
            public TestPage ()
            {
              InitializeComponent ();
              check();
            }
    
    
            private async Task submit(object sender, EventArgs e)
            {
               var httpClient = new HttpClient();
               httpClient.BaseAddress = Uri // I have changed the Uri variabele, you should extend this class and give it the same base address in the constructor.
               var resp= await httpClient.GetAsync("Machines");
                if (resp.Result.IsSuccessStatusCode)
                {
                    var repStr = resp.Result.Content.ReadAsStringAsync();
                    machines= JsonConvert.DeserializeObject<List<Machine>>(repStr.Result.ToString());
                }
            }
         }
    }
