        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected async void Button1_Click(object sender, EventArgs e)
        {
            string s = await GetAsyncMethod1();
            Label1.Text = s;
            //Or call this 
            //string s = await GetAsyncMethod2(); 
        }
        private string GetDataFromDB()
        {
            return  "Heres your data...";
        }
        private Task<string> GetAsyncMethod1()
        {
            //dbLayer
           return Task.Run(() => GetDataFromDB());
        }
        public async Task<string> GetAsyncMethod2()
        {
            //Optional business Layer - more processing
            string complicated = "";
            complicated = await GetAsyncMethod1();
            return complicated;
        }
