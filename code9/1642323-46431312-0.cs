     protected async void Button1_Click(object sender, EventArgs e)
        {
            var tasks = new List<Task>
            {
                Method1(),
                Method2(),
                Method3(),
                Method4(),
                Method5()
            };
            await Task.WhenAll(tasks);
        }
        public async Task Method1()
        {
            await Task.Delay(1000);
        }
        public async Task Method2()
        {
            await Task.Delay(1000);
        }
        public async Task Method3()
        {
            await Task.Delay(1000);
        }
        public async Task Method4()
        {
            await Task.Delay(10000);
        }
        public async Task Method5()
        {
            await Task.Delay(10000);
        }
