    async Task<List<PingReply>> GetRepliesAsync()
    {
      var PingIPs = PingAsync();
      MessageBox.Show("Loading:...");
      return await PingIPs;
    }
