            if ((!TextBoxJO.Text.StartsWith("NR")) || (TextBoxJO.Text.Length >= 12))
            {
                Button_Add.Enabled = false;
                LabelMessageJO.Text = "Wrong format";
                LabelMessageJO.Visible = true;
            }
            else
            {
                LabelMessageJO.Visible = false;
                Button_Add.Enabled = true;
            }
