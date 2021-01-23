    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.ComponentModel.DataAnnotations;
    namespace RequiredFieldsInClassExample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void btnTest_Click(object sender, EventArgs e) {
            try {
                lstStatus.Items.Clear();
                lstStatus.Items.Add("Creating list of people");
                List<Person> CollectionOfPeople = new List<Person>();
                lstStatus.Items.Add("Creating a good person");
                Person Jeff = new Person();
                Jeff.Age = 33;
                Jeff.Firstname = "Jeff";
                Jeff.Lastname = "Jefferson";
                Jeff.GroupCode = "JJJ";
                // LOOK! This line was added
                Jeff.Validate();
                CollectionOfPeople.Add(Jeff);
                lstStatus.Items.Add("Creating a bad person");
                Person Tim = new Person();
                Tim.Age = 444;
                Tim.Firstname = "";
                Tim.Lastname = "";
                Tim.GroupCode = "";
                // LOOK! This line was added
                Tim.Validate();
                CollectionOfPeople.Add(Tim);
                lstStatus.Items.Add("Done");
            } catch (ValidationException Exp) {
                MessageBox.Show(this, Exp.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } catch (Exception Exp) {
                MessageBox.Show(this, Exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
    }
