    foreach(Control c in panel1.Controls)
    {
        if (c is CustomButton)
        {
            (c as CustomButton).TopColor = Color.Red;
        }
    }
