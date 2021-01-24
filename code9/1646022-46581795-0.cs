        public class Marks
    {      
        public string FirstLastName { get; set; }
        public int MarksValue { get; set; }
        public string mySecondaryGrade { get; set; }
    }
     private void buttongradeStart_Click(object sender, RoutedEventArgs e)
        {
            // This runs through an if statement based on my radio buttons.
            //Testing that radio buttons work with my if else if statements
            // will change values to my grade function later
            Grade grader = new Grade();
            VET vetGrader = new VET();
            Marks secMarks = new ICTPRG406.Marks();
            PolyOveride overideVet = new PolyOveride();
            Helper myhelperArray = new Helper();
 
            //string x;
            if (dLoad == true)
            {
                //var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                System.Windows.Forms.SaveFileDialog saveDialogue = new System.Windows.Forms.SaveFileDialog();
                saveDialogue.Title = "Save File";
                saveDialogue.FileName = "Graded-Assessment1.csv";
                saveDialogue.Filter = "CSV Files(*.csv)|*.csv|Text Files(*.txt)|*.txt|All files(*.*)|*.*";
                saveDialogue.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (saveDialogue.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //var mySecondaryGrade = secMarks.mySecondaryGrade;
                    //IMPORTANT I NEED TO ADD THE GRADE OUTPUT TO MY LIST AND NOT JUST DISPLAY OUTPUT IN TEXTBOX
                    string v;
                    if (radioCollegeGrade.IsChecked == true )
                    {
                        foreach (Marks mMarks in myhelperArray)
                        {
                            v = grader.CollegeGrade(mMarks.MarksValue);                            
                            System.Windows.Forms.MessageBox.Show(mMarks.FirstLastName + " " + mMarks.MarksValue + " " + v);
                            mMarks.mySecondaryGrade = v;
                            //dataGridMarks.Columns[3] = mMarks.mySecondaryGrade;
                        }
                        using (var writer = new StreamWriter(saveDialogue.FileName))
                        {
                            foreach (Marks writeMarks in myhelperArray)
                            {
                                writer.WriteLine(writeMarks.FirstLastName + "," + writeMarks.MarksValue + "," + writeMarks.mySecondaryGrade);
                            }
                        }
                    }
                    else if (radioVetGrade.IsChecked == true)
                    {
                        foreach (Marks mMarks in myhelperArray)
                        {
                            v = vetGrader.VETGrade(mMarks.MarksValue);
                            System.Windows.Forms.MessageBox.Show(mMarks.FirstLastName + " " + mMarks.MarksValue + " " + v);
                            mMarks.mySecondaryGrade = v;
                        }
                        using (var writer = new StreamWriter(saveDialogue.FileName))
                        {
                            foreach (Marks writeMarks in myhelperArray)
                            {
                                writer.WriteLine(writeMarks.FirstLastName + "," + writeMarks.MarksValue + "," + writeMarks.mySecondaryGrade);
                            }
                        }
                    }
                    else if (radioCompetency.IsChecked == true)
                    {
                        foreach (Marks mMarks in myhelperArray)
                        {
                            v = overideVet.VETGrade(mMarks.MarksValue);
                            System.Windows.Forms.MessageBox.Show(mMarks.FirstLastName + " " + mMarks.MarksValue + " " + v);
                            mMarks.mySecondaryGrade = v;
                        }
                        using (var writer = new StreamWriter(saveDialogue.FileName))
                        {
                            foreach (Marks writeMarks in myhelperArray)
                            {
                                writer.WriteLine(writeMarks.FirstLastName + "," + writeMarks.MarksValue + "," + writeMarks.mySecondaryGrade);
                            }
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("I am not sure how you deslected a box!, you should probably select an option.");
                    }
                } 
                else
                {
                    System.Windows.Forms.MessageBox.Show("Placeholder Message");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("You have not selected a file for grading");
            }
        }
