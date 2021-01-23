        enum gender
        {
            Female,
            Male
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var value in Enum.GetValues(typeof(gender)))
            {
                genderComboBox.Items.Add(value.ToString());
            }
        }
