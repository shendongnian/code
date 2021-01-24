    //DONE: do not recreate Random
    private static Random s_Generator = new Random();
    private void pictureBox5_MouseClick(object sender, MouseEventArgs e) {
      const double p = 0.1; // each 1..5 has 0.1 probability, 6 - 0.5 
      // we have ranges [0..p); [p..2p); [2p..3p); [3p..4p); [4p..5p); [5p..1)
      // all numbers 1..5 are equal, but the last one (6)
      int value = (int) (s_Generator.NexDouble() / p) + 1;
      if (value > 6) 
         value = 6;        
      label2.Text = value.ToString();
    }
