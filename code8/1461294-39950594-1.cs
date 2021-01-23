        private void ChangeAllButtons()
        {
            foreach (var control in panel1.Controls.Cast<object>().Where(control => (control as TheButton) != null))
            {
                (control as TheButton).ChangeColor();
            }
        }
