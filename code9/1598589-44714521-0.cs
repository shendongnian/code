    btnClients_click(object sender, EventArgs e)
    {
        using (ClientsForms form = new ClientsForms())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                textBoxClient.Text = form.ClientName;
            }
        }
    }
