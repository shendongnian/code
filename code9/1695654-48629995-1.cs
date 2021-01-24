        private void Done_Button_Click(object sender, EventArgs e)
        {
            var dictionary = new Dictionary();
            dictionary.References();
            double Meter_Feet = dictionary.Length["Meters"];
    
            MessageBox.Show("Meter_Feet");
        }
