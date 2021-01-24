    public class ProjectViewModel : BaseViewModel
    {
        private string result;
        public string Result { get { return result; } set { result = value; NotifyPropertyChanged(); } }
    private void SendMessage()
    {
        {
            Task.Run(async delegate
            {
                try
                {
                    HttpContent content = new StringContent("");
                    content = new StringContent(SelectedRestMessage.Message);
                    content.Headers.ContentType = new MediaTypeHeaderValue(SelectedRestMessage.MessageType);
                    Result = await client.PostAsync(SelectedRestMessage.Adres, content).Result.Content.ReadAsStringAsync();        
                }
                catch (Exception e)
                {
                    Result = "Oeps Something went wrong";
                }
            });
        }
    }
