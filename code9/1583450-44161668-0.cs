    int countCharacters()
    {
      Thread.Sleep(5000);
      return 13;
    }
    private async void btnProcessFIle_Click(object sender, EventArgs e)
    {
      var count = await Task.Run(() => countCharacters());
      lblCount.Text = "No. of characters in file=" + count;
    }
