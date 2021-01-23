    public void LoadStudents()
        {
            var ofdLoadStudents = new OpenFileDialog();
            ofdLoadStudents.Multiselect = true;
            int Counter = 0;
            if (ofdLoadStudents.ShowDialog() == DialogResult.OK)
            {
                foreach (string studentList in ofdLoadStudents.FileNames)
                {
                    foreach (string Students in File.ReadAllLines(studentList))
                    {
                        //[Period 1]         | [ReadAllLines Data]
                        //has about 10 items | all "" fields.
                        //only loading total of 6 lines with 2 files combined.
                        listViewStudents.Items.Add(new ListViewItem(new string[] { Counter.ToString(), Students })); //This is the new code
                        Counter++;
                    }
                }
            }
        }
