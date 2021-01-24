    async void Button1_Click(object sender, EventArgs e)
    {
        try 
        {
            await StartClient();
            //Work with the client
        }
        catch(Exception exc)
        {
            MessageBox.Show(exc.ToString());
        }
    }
