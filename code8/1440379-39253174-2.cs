    private void Form1_Load(object sender, EventArgs e)
        {
            Button b = new Button();
            b.Name = "btnSubmit";// creating here for intellisense - you would create on your front-end
            bool recordExists = true;
            Button b1 = Controls.Find("btnSubmit", true)[0] as Button;
            //the above is for winforms - you'd have to change for web form
            b1.Text = recordExists ? "Update" : "Save";
            b1.Click += doUpdateOrSave;
            
        }
        protected void doUpdateOrSave(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Text == "Save")
            {
                //save
            }else
            {
                //update
            }
        }
