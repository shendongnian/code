        private void Form1_Load(object sender, EventArgs e)
        {
            int rowToDelete = 1;
            Button deleteBtn = new Button();
            deleteBtn.Text = "x";
            deleteBtn.Click += (snd, evtargs) => { RemoveRow(snd, evtargs, rowToDelete); };
        }
        private void RemoveRow(object sender, EventArgs e, int index)
        {
            //your code
        }
