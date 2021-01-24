    public partial class Form1 : Form
    {
        private int score = 0;
        private int randNum;
        private int guess = 0;
        private int guessCount = 0;
        private int maxGuesses = 15;
        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ResetGame();
        }
        private void ResetGame()
        {
            // Choose new random number
            randNum = rnd.Next(1, 101);
            lblDebug.Text = randNum.ToString();
            // Reset variables
            guessCount = 0;
            lblGuessCount.Text = guessCount.ToString();
            txtGuess.Text = "";
            // Show instructions
            MessageBox.Show("I've chosen a random number from 1 to 100. You have 15 tries to guess it!");
        }
        private void btnGuess_Click(object sender, EventArgs e)
        {
            CheckForWinner();
        }
        private void CheckForWinner()
        {
            if (guess == randNum)
            {
                // Increment the score
                score += 1;
                lblScore.Text = score.ToString();
                // Tell user they won, and reset game
                MessageBox.Show($"Congratulations! You guessed the number in {guessCount} tries!");
                ResetGame();
            }
            else
            {
                // Tell them if they're too high or low, and finish this turn
                DisplayHighLowMessage();
                FinalizeTurn();
            }
        }
        private void DisplayHighLowMessage()
        {
            MessageBox.Show(guess < randNum ? "That guess is too low!" : "That guess is too high!");
        }
        private void FinalizeTurn()
        {
            // Increment guess count
            guessCount++;
            lblGuessCount.Text = guessCount.ToString();
            // If they've used all their guesses, show them the number and reset the game
            if (guessCount > maxGuesses)
            {
                MessageBox.Show($"Sorry, you're out of guesses! The number was: {randNum}.");
                ResetGame();
            }
        }
        private void txtGuess_TextChanged(object sender, EventArgs e)
        {
            // If the textbox is being cleared, allow it and reset the guess.
            if (txtGuess.Text == "")
            {
                guess = 0;
            }
            // Otherwise, use int.TryParse to set our guess variable in case 
            // the 'Text' property doesn't contian a valid number
            // The code below says, "if TryParse fails, reset the text back to our number"
            else if (!int.TryParse(txtGuess.Text, out guess))
            {
                txtGuess.Text = guess.ToString();
            }
        }
    }
