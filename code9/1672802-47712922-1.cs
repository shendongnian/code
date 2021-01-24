                    List<int> numbers = new List<int>();
                    private void buttonAdd_Click(object sender, EventArgs e)
                    {
                        if (radioButtonSorted.Checked)
                        {
                            numbers.Clear();
            
                            if (!string.IsNullOrEmpty(textBoxInsert.Text))
                                numbers.Add(int.Parse(textBoxInsert.Text));
            
                            foreach (var item in listBoxAddedIntegers.Items)
                            {
                                if (item != null)
                                    numbers.Add(int.Parse(item.ToString()));
                            }
            
                            listBoxAddedIntegers.Items.Clear();
                            numbers.Sort();
                            foreach (var number in numbers)
                                listBoxAddedIntegers.Items.Add(number);
                        }
                        else
                            listBoxAddedIntegers.Items.Add(textBoxInsert.Text);
            
                        textBoxInsert.Text = string.Empty;
                        //MessageBox.Show(listBoxAddedIntegers.SelectedIndex.ToString());
                        MessageBox.Show(listBoxAddedIntegers.Items.Count.ToString());
                        }
