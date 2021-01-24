            public static void Main()
            {
                var form = new InputForm();
        
                var tbName = form.AddTextBox( "Name", new InputForm.TextBoxAttributes {
                    ForeColor = Color.Yellow,
                    BackColor = Color.Blue
                });
                var tbAge = form.AddTextBox( "Age", new InputForm.TextBoxAttributes {
                    ForeColor = Color.Green,
                    BackColor = Color.Black,
                    Bold = true
                });
                var tbAddress = form.AddTextBox( "Address" );
        
                form.Show();
                Application.Run( form );
            }
