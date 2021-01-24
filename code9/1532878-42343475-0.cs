    public class Form
    {
            // your code ...
    
            string q = combobox1.SelectedItem.ToString();
            int g = Convert.ToInt32(q);
            MessageBox.Show("I have added " +(g-1) +" Films to the list");
            public TextBox[] FilmTitle1 = new TextBox[int.Parse(q)];
            public TextBox[] FilmBudget1 = new TextBox[int.Parse(q)];
            public TextBox[] FilmBoxOffice1 = new TextBox[int.Parse(q)];
            public TextBox[] FilmDirector1 = new TextBox[int.Parse(q)];
            public TextBox[] FilmRtScore1 = new TextBox[int.Parse(q)];
            public TextBox[] FilmGenre1 = new TextBox[int.Parse(q)];
            int y = 500;
            for (int i = 0; i < g; i++)
            {
                FilmTitle1[i] = new TextBox();
                FilmTitle1[i].Text = "Film Title";
                FilmTitle1[i].Size = new Size(162, 20);
                FilmTitle1[i].Location = new Point(106, y);
                FilmTitle1[i].Tag = 0;
                this.Controls.Add(FilmTitle1[i]);
                y= y + 40;
    
        private void Createbar_Click(object sender, EventArgs e)
        {
            BarGraphCreation frm = new BarGraphCreation(this);
           frm.Show();
        }
    }
    public class BarGraphCreation
    {
        // your code...
        
        Form form;
        public BarGraphCreation(Form form)
        {
            // ...
            this.form = form;
        }
        private void function()
        {
            // here you can work with your data like
            // form.FilmTitle1 and so on
        }
    }
