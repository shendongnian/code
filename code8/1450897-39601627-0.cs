    public partial class WebPageSeparated : System.Web.UI.Page
    
    {
    
    private int randNum;
    private int theirGuess;
    protected void Page_Load(object sender, EventArgs e)
    {
        Random randomNum = new Random();
        randNum = randomNum.Next(0, 10);
        theirGuess = 0;
        Label1.Text = "Guessing game! Guess a number between [0,10) to see if you can get it right!";
        new WebPageSeparated();
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
           try
            {
                theirGuess = Convert.ToInt32(TextBox1.Text);
                if (theirGuess != this.randNum)
                {
                    Label1.Text = "Sorry, wrong number.  Please try again!";
                }
                else if(theirGuess == this.randNum)
                {
                    Label1.Text = "Correct! A new number has been generated, go ahead and try to do it again!";
                    new WebPageSeparated();
                }
            }
            catch (System.FormatException)
            {
                Label1.Text = "Enter a number [1,10)";
            }
        }
