    public async Task<ResponseMessage> Send(RequestMessage message)
    {
      var id = Guid.NewGuid();
      var ret = Inbound.FirstAsync((x) => x.id == id).Timeout(timeout).ToTask();
      await DoSendMessage(id, message);
      return await ret;
    }
