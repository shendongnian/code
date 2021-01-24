    private void B_Click(object sender, System.EventArgs e)
        {
            //certain angle decided by EditText's text
            Int32 number = int.Parse(et.Text.ToString());
            drawview.Angle = number;
        }
