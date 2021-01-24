    private void btnLogin_Click(object sender, EventArgs e)
    {
        loading.Visible = true;
        Task.Run<bool>(() =>
            {
                return ConnectDataBase();
            })
            .ContinueWith(t =>
            {
                if (t.Result)
                {
                    OpenForm2();
                    this.Close();
                }
                else MessageBox.Show("User or password, incorrect");
            }, TaskScheduler.FromCurrentSynchronizationContext());
    }
