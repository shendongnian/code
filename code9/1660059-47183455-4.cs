    using (var db = new DataContext())
                {
                    Person new_person = new Person();
                    new_person.Name = textBox1.Text;
                    new_person.Surname = textBox2.Text;
                    new_person.Job = textBox3.Text;
                    new_person.Phone = Int32.Parse(textBox4.Text);
                    new_person.Mobile = Int32.Parse(textBox5.Text);
                    new_person.Company.Id = (comboBox1.SelectedItem as CBItem).Value;
                    db.Person.Add(new_person);
                    db.SaveChanges();
                    MessageBox.Show("Person successfully added!");
                    this.Close();
                }
