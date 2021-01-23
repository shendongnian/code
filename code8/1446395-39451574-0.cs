          if (!this.Controls.ContainsKey("dateTimePickerLogInicial")
                && !this.Controls.ContainsKey("dateTimePickerLogFinal"))
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
                    this.Controls.Add(dtInical);
                    this.Controls.Add(dtFinal);
            }
            else
            {
                this.Controls.RemoveByKey("dateTimePickerLogInicial");
                this.Controls.RemoveByKey("dateTimePickerLogFinal");
            }
