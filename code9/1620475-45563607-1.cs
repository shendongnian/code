    class Window1 : Window
    {
        Patient _patient;
        public Patient Patient
        {
            get { return _patient; }
        }
    
        // rest of your code
     
        void button_Click(object sender, RoutedEventArgs e)
        {
            _patient = new Patients(lstname.Text, frstname.Text, age.Text, rm.Text, "", status.SelectedItem.ToString());
            DialogResult = true;
            Close();
        }
    }
