    private void resetButton_Click(object sender, EventArgs e)
        {
            //........
            StreamReader fileIn;
            displayDGV.DataSource = null;
            displayDGV.Rows.Clear();
            displayDGV.Refresh();
            displayDGV.EditMode = DataGridViewEditMode.EditProgrammatically;
            string DATA_FILE_NAME = "C:\\Dgvnums.txt";//e.g. a sample name 
            if (File.Exists(DATA_FILE_NAME))
                fileIn = File.OpenText(DATA_FILE_NAME);
            else
            {
                MessageBox.Show(DATA_FILE_NAME + " does not exist", "Abort Execution",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int lincnt = 0;
            string teststr = "";//the following counts the Lines included in the txt file
            while (!fileIn.EndOfStream)
            {
                teststr = fileIn.ReadLine();
                if (teststr != "")
                {
                    lincnt++;
                }
            }
            fileIn.Close();
            int index = int.Parse(textBox1.Text.ToString());
            if (index > lincnt)
            {
                MessageBox.Show("THE FILE CONTAINS LESS NUMBERS THAN YOU HAVE SPECIFIED");
                return;
            }
            fileIn = File.OpenText(DATA_FILE_NAME);
            listBox1.Items.Clear();//the folloing loads the numbers in the listBox1
            for (int i = 1; i <= index; i++)
            {
                string toreadstr = fileIn.ReadLine();
                if (toreadstr.Contains("-"))
                {
                    toreadstr = toreadstr.Replace("-", "");
                }
                listBox1.Items.Add(Int32.Parse(toreadstr));
            }
            fileIn.Close();
            DataTable mytab = new DataTable();
            mytab.Columns.Add();
            for (int i = 0; i < index; i++)
            {
                object[] numbr = new object[1];
                numbr[0] = new object();
                numbr[0] = (object)listBox1.Items[i];
                mytab.LoadDataRow(numbr, true);
            }
            displayDGV.DataSource = mytab;
            displayDGV.Columns[0].HeaderText = "Mynumbers";
            displayDGV.AllowUserToAddRows = false;
            displayDGV.Refresh();
        }
