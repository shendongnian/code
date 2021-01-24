	private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
	{
		string[] BlockedWordsArray = BlockedWords.ToArray();
		for (int i = 0; i < BlockedWordsArray.Length; i++)
		{
			if (SearchBar.Text.IndexOf(BlockedWordsArray[i], StringComparison.OrdinalIgnoreCase) > -1)
			{
				e.Cancel = true;
				player.SoundLocation = "nono.wav";
				player.Play();
				MessageBox.Show("Booyaa Says No!", "Blocked", MessageBoxButtons.OK, MessageBoxIcon.Hand); // Block List Error Message
			} 
		}
	}
