        isLabelClicked = true;
    }
    public static void f1_keydown(object sender, KeyEventArgs e)
    {
        if (isLabelClicked == true)
        {
            if (e.KeyCode == Keys.A)
            {
                l1.Text += "a";
            }
            else if (e.KeyCode == Keys.B)
            {
                //Etc. For each key
            }
        }
    }
