    private async Task<int> TestNoLongerSynchronousAsync()
    {
      return await this.TestAsync();
    }
    private async void button_Click(object sender, EventArgs e)
    {
      MessageBox.Show((await this.TestNoLongerSynchronousAsync()).ToString());
    }
