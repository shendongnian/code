    private void mtbCNIC_TextChanged(object sender, EventArgs e)
    {
        mtbCNIC.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        btnSave.Enabled = mtbCNIC.Text != string.Empty;
        mtbCNIC.TextMaskFormat = MaskFormat.IncludeLiterals;
    }
