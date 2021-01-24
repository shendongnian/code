        public override async void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
       
            await LoadData();
        }
        private async Task LoadData()
        {
         //My async method 
        }
