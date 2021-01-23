    public class YourGame : Form // I guess it's a Form
    {
        private Random randomGenerator = new Random();
        private int a;
        private int b;
        private int score;
     
        public void CreateQuestion()
        {
            a = randomGenerator.Next(10) + 1;
            b = randomGenerator .Next(10) + 1;
            if (b > a)
            {
                // switch values
                int tmp = b;
                b = a;
                a = tmp;
            }
  
            lb_getal1.Text = a.ToString();
            lb_getal2.Text = b.ToString();            
        }
        private void OnAnswer()
        {
            int c = a - b; // will never be negative as we checked a and b above
            if (txt_antwoord.Text == c.ToString())
            {
                MessageBox.Show("You provided the right answer!");
                score += 1;
                CreateQuestion();
            }
            else
                MessageBox.Show("You were wrong!");
            if (score == 5)
            {
                MessageBox.Show("You answered 5 answers correctly! Well done!");
                this.Close();
                RM_menu form = new RM_menu();
                form.Show();
            }
        }
    }
