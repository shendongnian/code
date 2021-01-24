    private Dictionary<string, TextBox> dynamicTextBoxes = new Dictionary<string, TextBox>();
    public System.Windows.Forms.TextBox AddNewTextBox()
    {
        System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
        this.Controls.Add(txt);
        dynamicTextBoxes.Add($"tb{cLeft}", txt);
        txt.Top = cLeft * 25;
        txt.Left = 100;
        txt.Text = "TextBox " + this.cLeft.ToString();
        cLeft = cLeft + 1;
        return txt;
    }
    private void button3_Click(object sender, EventArgs e)
    {
        ControlMoverOrResizer.Init(dynamicTextBoxes[$"tb{cLeft - 1}"]);
        cboWorkType.SelectedIndex = 0;
    } 
