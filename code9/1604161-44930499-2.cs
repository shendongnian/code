    private void Preiststop_Click(object sender, EventArgs e)
    {
        j = true;
    }
    private async void Preist_Click(object sender, EventArgs e)
    {
        await Task.Run(() => {
            while (!j)
            {
                SendKeys.Send(" ");
                Thread.Sleep(5000);
            }
        });
    }
