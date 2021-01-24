    class ColourForm
    {
       public Color SelectedColor {get;set;}
    
        private void Panelcolor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;
    
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
    
                this.SelectedColor = colorDlg.Color;
    
    
            }
        }
    
       void Cancel()
       {
           this.DialogResult = DialogResult.Cancel;
           this.Close();
       }
    
       void Save()
       {
           this.DialogResult = DialogResult.OK;
           this.Close();
       } 
    }
