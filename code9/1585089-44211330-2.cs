    public partial class Form1 : Form
    {
        Random rnd = new Random();
        var possibles = new int[]{0,1,2,3,4,5.....,26}
        // The rest of your code here
        private void button1_Click(object sender, EventArgs e)
        {
            int randomNumber = -1;
            while (randomNumber == -1)
            {
                randomNumber = possibles[rnd.Next(0, 25)];
                if randomNumber > 0
                {
                    possibles[randomNumber] = -1;
                }
            }
            // Do something with the random number
            
            
