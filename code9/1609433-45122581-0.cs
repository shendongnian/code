    private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(messageTextBox.SelectedText);
            MessageBox.Show("You Have Copy The Link The Message Will Bee Delete Now...");
            deletemenssage();
        }
