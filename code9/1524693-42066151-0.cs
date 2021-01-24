    protected override void OnPreviewTextInput(TextCompositionEventArgs e)
    {
        base.OnPreviewTextInput(e);
        if (e.Text == "/")
        {
            Debug.WriteLine("...");
        }
    }
