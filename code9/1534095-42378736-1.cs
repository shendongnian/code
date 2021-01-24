    private void rdbDX11_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbDX11.Checked == true)
        {
            pbOGL3Outer.Visible = false;
            pdDX11Outer.Visible = true;
            pdDX9Outer.Visible = false;
            rdbDX9.Checked = false;
            rdbOGL3.Checked = false;
            Properties.Settings.Default.varRenderSelected = ("DirectX11");
            // Read
            var ReWriteFile = File.ReadAllText(Properties.Settings.Default.SavedConfig);
            // Edit
            ReWriteFile = ReWriteFile
              .Replace("  driver:t=\"dx9\"", "  driver:t=\"dx11\"") 
              .Replace("  driver:t=\"gl3\"", "  driver:t=\"dx11\"")
              .Replace("  driver:t=\"auto\"", "  driver:t=\"dx11\"");
            // Write back
            File.WriteAllText(Properties.Settings.Default.SavedConfig, ReWriteFile);
        }
    }
