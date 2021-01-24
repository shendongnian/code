    public void updateTextView(string s) 
    {
        RunOnUiThread(() =>
		{
            yourTextView.Text = s;//set your TextView here
        });
    }
