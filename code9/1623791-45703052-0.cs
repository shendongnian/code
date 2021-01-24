        private async static Task<int> RegisterProductAsync(string productName)
        {
            try
            {
                await Task.Run(() => myWebService.Register(productName));
                return 0;
            }
            catch (Exception ex)
            {
                LogException();
                return 1;
            }
        }
        public async Task<int> RegisterProduct(string productName)
        {
            var result = await RegisterProductAsync(productName);
            return result;
        }
