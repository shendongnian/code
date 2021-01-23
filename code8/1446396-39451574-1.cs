          if(tableLayoutPanel2.Controls.ContainsKey("dateTimePickerLogInicial"))
             tableLayoutPanel2.Controls.RemoveByKey("dateTimePickerLogInicial");
           if(tableLayoutPanel2.Controls.ContainsKey("dateTimePickerLogFinal"))
               tableLayoutPanel2.Controls.RemoveByKey("dateTimePickerLogFinal");
                //Your Code Like This
                if (cbxBaseDados.Text.Equals("Value"))
                {
                    var dtInical = new DateTimePicker()
                    {
                        Name = "dateTimePickerLogInicial",
                        Size = new Size(135, 68),
                        Margin = new Padding(3, 9, 3, 3)
                    };
                    var dtFinal = new DateTimePicker()
                    {
                        Name = "dateTimePickerLogFinal",
                        Size = new Size(135, 68),
                        Margin = new Padding(3, 9, 3, 3)
                    };
                    lbPeriodo.Hide();
                    periodoTimePicker1.Hide();
                    periodoTimePicker2.Hide();
                    txtPeriodo1.Hide();
                    txtPeriodo2.Hide();
                    tableLayoutPanel2.ColumnCount = 13;
                    tableLayoutPanel2.Controls.Add(dtInical, 6, 0);
                    tableLayoutPanel2.Controls.Add(lbAPeriodo, 7, 0);
                    tableLayoutPanel2.Controls.Add(dtFinal, 8, 0);
                }
