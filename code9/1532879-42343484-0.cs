    public class Form1 : Form
    {
        private TextBox[] FilmTitles;
        private List<TextBox> FilmBudget = new List<Textbox>();
        //code removed for brevity
        private void Button1_Click( /***/ )
        {
            FilmBudget.Clear();
            int count = Convert.ToInt32(q);
            FilmTitles = new TextBox[count];
            for (int i = 0; i < count; i++)
            {
                FilmTitles[i] = new TextBox()
                {
                    Text = "Programmer in one day",
                    Size = new Size(162, 20)
                    // all other definitions
                };
                FilmBudget.Add(new TextBox()
                {
                    Text = "1225",
                    Size = new Size(162, 20)
                    // all other definitions
                };
                this.Controls.Add(FilmTitles[i]);
                this.Controls.Add(FilmBudget[i]);
                //Now you are holding all the TB & text in global variables (arrays/lists)
            }
        }    
        private void Createbar_Click(object sender, EventArgs e)
        {
        
            BarGraphCreation frm = new BarGraphCreation(
                   FilmTitles.Select( a => a.Text).ToArray(),
                   FilmBudget.Select( a => a.Text).ToArray());
            frm.Show();
        }    
    }
