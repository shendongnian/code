    private void CreateWhiteLayerForm()
    {
        whiteLayerForm = new Form();
    
        int titleHeight = SystemInformation.CaptionHeight;
        int borderHeight = SystemInformation.FrameBorderSize.Height;
        int borderWidth = SystemInformation.FrameBorderSize.Width;
    
        // The white layer should not cover the title bar
        whiteLayerForm.Size = new System.Drawing.Size(Global.MainForm.Size.Width, Global.MainForm.Size.Height - titleHeight);
        whiteLayerForm.Location = new System.Drawing.Point(Global.MainForm.Location.X , Global.MainForm.Location.Y + borderHeight + titleHeight);
        whiteLayerForm.StartPosition = FormStartPosition.Manual;
    
        whiteLayerForm.AutoScaleMode = AutoScaleMode.None;
        whiteLayerForm.ShowInTaskbar = false;
    
        whiteLayerForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        whiteLayerForm.BackColor = System.Drawing.Color.White;
        whiteLayerForm.Opacity = 0.5;
    }
