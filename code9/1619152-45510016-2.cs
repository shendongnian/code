    private void OnInfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            for (var index = 0; index < e.Errors.Count; index++)
            {
                var message = e.Errors[index];
                //use the message object
            }
        }
