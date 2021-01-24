    private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;
            // return our reply to the user
            await context.PostAsync($"You sent {activity.Text} which was {length} characters");
            // 
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://outlook.office.com/webhook/.../IncomingWebhook/.../...");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    text = "\"" + activity.Text + "\""
                });
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            //Make the actual request
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //Get the output
                var result = streamReader.ReadToEnd();
            }
            //
            context.Wait(MessageReceivedAsync);
        }
