            List<TextBox> TextBoxes = new List<TextBox>() {
                tb1n,
                tb2n,
                tb3n,
                ...
            };
            List<string> mySettings = new List<string>(){
                Settings2.Default.tb1n,
                Settings2.Default.tb2n,
                Settings2.Default.tb3n,
                ...
            };
            foreach  (TextBox item in TextBoxes)
            {
                item.Text = mySettings[TextBoxes.FindIndex(a => a.Name == item.Name)];
            }
