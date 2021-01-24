    private void button1_Click(object sender, EventArgs e)
        {
            CustomToolTip toolTip1 = new CustomToolTip();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(button1, "Click me to execute.");
            toolTip1.EndSpecialText = "Hello I am special";
        }
