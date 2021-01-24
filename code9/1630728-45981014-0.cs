    using (inputbox ipfirst = new inputbox("Enter Customer First Name:", "", ""))
                        {
                            if (ipfirst.ShowDialog() == DialogResult.OK)
                            {
                                newfirstname = ipfirst.answer;
                            }
                            else
                            {
                                DialogResult = DialogResult.Cancel;
                                return;
                            }
                        }
