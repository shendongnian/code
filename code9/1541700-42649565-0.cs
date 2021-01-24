    private void btnAddPatient_Click(object sender, RoutedEventArgs e)////Add Patients
    {
        string name = txtPatientName.Text;
        int bloodType,age=30;           
        DateTime dob;
        bool bloodA = rbA.IsChecked.Equals(true);
        bool bloodB = rbB.IsChecked.Equals(true);
        bool bloodAB = rbAB.IsChecked.Equals(true);
        bool blood0 = rb0.IsChecked.Equals(true);
		var bloodTypeDefined = bloodA || bloodAB || bloodB || blood0;
        // if (dpDOB.SelectedDate == null || txtPatientName.Text == ""||bloodType==0)
        if (dpDOB.SelectedDate == null || txtPatientName.Text == "" || !bloodTypeDefined)
        {
            if (txtPatientName.Text == "")
            {
                MessageBox.Show("Please enter Patient's Name");
            }
            else if (!bloodTypeDefined)
            {
                MessageBox.Show("Please enter patient's blood type");
            }
            //else if (dpDOB.SelectedDate == null)
            //{
            //    MessageBox.Show("Please select a date");
            //}
        }
        else
		{
		   if (bloodA) bloodType = 0;
 		   else if (bloodB) bloodType = 1;
			else if (bloodAB) bloodType = 2;
			else bloodType = 3;           
            dob = dpDOB.SelectedDate.Value;
            Patient patient= new Patient(name, age, bloodType);///cant get bloodtype value
            MainWindow mainWindow = Owner as MainWindow;
           patients.Add(patient);
            lstPatients.ItemsSource = null;
            lstPatients.ItemsSource = patients;			
		}
            // this.Close();
        }
