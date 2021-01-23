    class Student {
            public int ID{get;set;}
            public string Name { get; set; }
            
            // You override this method depending in what you want to show on the comboBox as text
            public override string ToString()
            {
                return Name;
            }
        }
        private void fillComboBox(List<Student> students)
        {
            // We manually fill the comboBox Items; The displayed text is going to be define by the ToString() method this object has define
            students.ForEach(x => cmb1.Items.Add(students));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // We can remove the items by just doing this
            cmb1.Items.Remove(cmb1.SelectedItem);
        }
