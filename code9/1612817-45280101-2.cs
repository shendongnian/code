    private async void btnLogin_Click (object sender, EventArgs e)
    {
         loading.Visible = true;
         if (await Task.Run(() => ConnectDataBase()))
         {
             OpenForm2();
             This.Close();
         }
         else MessageBox.Show ("User or password, incorrect");
         loading.Visible = false;
    }
