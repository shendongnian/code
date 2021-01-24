            string input = TextEditor.Text;
            if (input != " ")
            {
                string[] command = { "create", "if" };
                if (input.ToLower().Contains(command[0]))
                {
                    Output.Text = "Token: CREATE";
                    string[] type = { "variable", "boolean" };
                    if (input.ToLower().Contains(type[0]))
                    {
                        Output.Text += "\nToken: VARIABLE";
                       // Output. AppendText(Environment.NewLine);  //this is supposed to change to the next line but for some reason it doesnt. 
                        string[] variable = { "value", "called" };
                        if (input.ToLower().Contains(variable[0]))
                        {
                            Output.Text = "Token: VALUE";
                        }
                    }
                }
            }
            else
            {
                Output.Text = " ";
            }
