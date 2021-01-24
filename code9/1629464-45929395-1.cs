        using (TextFieldParser csvParser = new TextFieldParser(path)) {
                        csvParser.CommentTokens = new string[] { "#" };
                        csvParser.SetDelimiters(new string[] { "," });
                        csvParser.HasFieldsEnclosedInQuotes = true;
        
                        csvParser.ReadLine();
        
    int offsetX = 30;
    int offsetY = 40;
    int counter;
        
                        while (!csvParser.EndOfData) {
                        int pointerY = ++counter * offsetY; // first counter increments by one, then counter times offsetY occurs
                        int pointerX;
    
                            string[] fields = csvParser.ReadFields();
                            int rowNums = fields.Length;
        
                            for(int index = 0; index < rowNums;index++) {
    pointerX = (index + 1) * offsetX;
    
                                string name = fields[index];
                                TextBox n = new TextBox() { Text = name, Location = new Point(pointerX, pointerY) };
                                panel2.Controls.Add(n);
                                panel2.Show(); // should be unnecessary
                            }
                        }
                    }
