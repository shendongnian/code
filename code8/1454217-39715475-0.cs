    public void SetPortNameValues(object obj)
        {
            string[] ports = SerialPort.GetPortNames(); // load all name of com ports to string
            ((ComboBox)obj).Items.Clear(); //delete previous names in combobox items
            foreach (string port in ports) //add this names to comboboxPort items
            {
                ((ComboBox)obj).Items.Add(port); //if there are some com ports ,select first
            }
            if (((ComboBox)obj).Items.Count > 0)
            {
                ((ComboBox)obj).SelectedIndex = 0;
            }
            else
            {
                ((ComboBox)obj).Text = " "; //if there are no com ports ,write Empty
            }
        }
