                        string tempnum = "txtbox";
                        TemplateField temp1 = new TemplateField();
                        temp1.HeaderStyle.Width = Unit.Pixel(101);
                        temp1.HeaderStyle.CssClass = "headerwidth";
                        temp1.HeaderText = "txt";
                        temp1.ItemTemplate = new CreateTextBox(tempnum);
                        GridView1.Columns.Add(temp1);
                       
