        private void OnButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button) sender;
            if (clickedButton != null)
            {
                string buttonContent = clickedButton.Text;
                CheckAndAdd(buttonContent);
            }
        }
        private void CheckAndAdd(string valueToCheck)
        {
            if (!My_Pizza.Items.Contains(valueToCheck))
            {
                My_Pizza.Items.Add(valueToCheck);
            }
        }
