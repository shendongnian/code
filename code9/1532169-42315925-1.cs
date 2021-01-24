    public class SendReciveSoapData
    {
        private string[] UUID_array { get; set; }
        private string CurrentUUID { get; set; }
        public void InvokeSend(string[] uuid_array)
        {
            int len = uuid_array.Length;
            if (len > 0)
            {
                CurrentUUID = uuid_array[0].ToString();
                string strToRemove = CurrentUUID;
                UUID_array = uuid_array.Where(val => val != strToRemove).ToArray();
                invokeSend(CurrentUUID);
            }
        }
        private void invokeSend(string uuid)
        {
            CurrentUUID=uuid;
            WebRef.ResponderService RespService = new WebRef.ResponderService();
            RespService.SendDataAsync(uuid);
            RespService.SendCompleted += RespService_Send_Completed;
        }
        void RespService_Send_Completed(object sender, WebRef.CompletedEventArgs e)
        {
            //Saving Response Data to database
            string SuccessID = e.Result;
            string TransactionID = CurrentUUID;
            DataBase db = new DataBase();
            db.UpdateResponseID(SuccessID, TransactionID);
            InvokeSend(UUID_array);
        }
    }
