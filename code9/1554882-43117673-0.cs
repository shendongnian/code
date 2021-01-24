        public void YourMethod()
        {
            
            if (e.Key == Key.Delete)
            {
                //Could I show window here like like "Loading please wait.."
                FireAndForget();
                //When this is done close this method
            }
        }
        public async void FireAndForget()
        {
            await Task.Run(() => { ExecuteLongMethod(); });
        }
