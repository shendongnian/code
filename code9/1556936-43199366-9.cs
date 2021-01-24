    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace DemoProject
    {
        public partial class Form1 : Form
        {
            DataFile firstFile;
            DataFile secondFile;
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        string sFileName = dialog.FileName;
                        pathFolder = sFileName;
                        label3.Text = pathFolder;
                        label3.Show();
                        firstFile = DataFile.Load(dialog.FileName);
                        if(firstFile.CheckStation())
                        {
                            MessageBox.Show("Файла с дневни данни трябва да съдържа само една станция!");
                        }
                    }
                }
            }
            private void button2_Click(object sender, EventArgs e)
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        string sFileName = dialog.FileName;
                        pathFolder2 = sFileName;
                        label4.Text = pathFolder2;
                        label4.Show();
                        string[] lines = System.IO.File.ReadAllLines(dialog.FileName);
                        int i = 0;
                        secondFile = DataFile.Load(dialog.FileName);
                        if (secondFile.CheckStation())
                        {
                            MessageBox.Show("Файла с месечни данни трябва съдържа само една станция!");
                            return;
                        }
                    }
                }
            }
            private void button3_Click(object sender, EventArgs e)
            {
                if (firstFile != null && secondFile != null)
                {
                    if (firstFile.Entries.First().Station != secondFile.Entries.First().Station)
                    {
                        MessageBox.Show("Номера на станцията в единия файл не отговаря на номера на станцията в другият файл!" + Environment.NewLine + Environment.NewLine +
                            "ЗАБЕЛЕЖКА!" + Environment.NewLine + Environment.NewLine + "В двата файла, номера на станцията трябва да бъде един и същ!");
                    }
                    comboBox1.Items.Add(firstFile.Entries.First().Station);
                    if (firstFile.CheckYears(secondFile))
                    {
                        comboBox2.Items.AddRange(firstFile.GetYears());
                    }
                    else
                    {
                        MessageBox.Show("Годините от двата файла не съвпадат.");
                    }
                }
                else
                {
                    MessageBox.Show("One or both files are empty. Please select the file and read the data first.");
                }
            }
            public void loadEntries()
            {
                string selectedYear = this.comboBox2.SelectedValue.ToString();
                DataEntry[] entries = firstFile.GetAllEntriesOfOneYear(selectedYear);
            
                //TODO:
                //Now you have all lines of the first file which have the selected year.
                //With this list you can work
            }
        }
    }
