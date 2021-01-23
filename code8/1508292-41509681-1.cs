    public Form1()
    {
        InitializeComponent();
        /* Once you call the InitializeComnents method you will be able to access controls added in design view */
        Clipboard.SetText(txtCopy.Text);
        txtPaste.Text = Clipboard.GetText();
    }
