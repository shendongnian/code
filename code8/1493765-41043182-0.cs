        try {
            await Task.WhenAll(chunks.Select(MakeCall));
        }
        catch (Exception) {
            _client.CancelPendingRequests();
        }
        private async Task MakeCall(string chunk) {
            var response = await _client.PostAsync(chunk);
            if (!response.IsFaulted) {
                //Do something
            }
            else {
                this._logger.Error("log the error");
                throw new Exception("call failed!");
            }
        }
