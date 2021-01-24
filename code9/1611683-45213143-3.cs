    void OnCallJavaScriptButtonClicked (object sender, EventArgs e)
    {
      ...
      int number = int.Parse (numberEntry.Text);
      int end = int.Parse (stopEntry.Text);
    
      webView.Eval (string.Format ("printMultiplicationTable({0}, {1})", number, end));
    }
