    private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
      _repo = _serviceProvider.GetService(typeof(IRepository) as IRepository
      string result = System.Text.Encoding.UTF8.GetString(e.Message);
      Item item = new Item {name = result};
      _repo.AddMyItem(item);
    }
