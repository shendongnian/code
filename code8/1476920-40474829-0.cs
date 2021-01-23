     private void mqttClient_MsgPublishReceived(object sender, MqttMsgPublishEventArgs eventArgs)
    {
        string message = Encoding.UTF8.GetString(eventArgs.Message);
        //here instead of View.Writelog(message);
    }
