        static async void MakeRequests()
        {
            var requests = new List<Task<bool>>();
            for (int i = 1; i <= 10; i++)
            {
                // no await here, so, not await MakeRequest(i);
                requests.Add(MakeRequest(i));
            }
            // now all 10 requests are running in parallel
            try {
                await Task.WhenAll(requests);
            }
            catch {
               // no need to handle it here - we handle all errors below 
            }
            // if we are here, all requests are either completed or failed, inspect their results
            foreach (var request in requests) {
                if (request.IsCanceled) {
                    // failed by timeout
                }
                else if (request.IsFaulted) {
                    // failed
                    Log(request.Exception);
                }
                else {
                    // success
                    bool result = request.Result;
                    // handle your result here if needed
                }
            }
        }
        static async Task<bool> MakeRequest(int i) {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(@"http://fake-response.appspot.com/api/?data={Hello World}&sleep=30");
                //client.BaseAddress = new Uri(@"http://fake-response.appspot.com/api/?data={Hello World}&status=200");
                // no timeout here, or set to max expected delay
                //client.Timeout = new TimeSpan(0, 0, 60);
                var parameters = new Dictionary<string, string>();
                parameters["ContentType"] = "text/plain;charset=UTF-8";
                //Create Task to POST to the URL
                client.DefaultRequestHeaders.ExpectContinue = true;
                var response = await client.PostAsync(client.BaseAddress, new FormUrlEncodedContent(parameters));
                Task<bool> b1 = ProcessURLAsync(response, 1, 5, 2);
                return b1;
            }
        }
