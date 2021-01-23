    bool suppressTextChanged = false;
    private void mtbCNIC_TextChanged(object sender, EventArgs e)
    {
        if (suppressTextChanged)
            return;
        suppressTextChanged = true;
        mtbCNIC.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        btnSave.Enabled = mtbCNIC.Text != string.Empty;
        mtbCNIC.TextMaskFormat = MaskFormat.IncludeLiterals;
        suppressTextChanged = false;
    }
