    private void button1_Click(object sender, EventArgs e)
    {
        int guess;
        if (int.TryParse(textBox1.Text, out guess))
        {
            var direction = guess > numberToGuess ? "lower" : "higher";
            var incorrectMsg = $"Sorry, that's not it - try a {direction} number.";
            if (guess == numberToGuess)
            {
                MessageBox.Show($"Good job! You got it in {guesses.Count + 1} tries!");
                guesses.Clear();
                numberToGuess = rnd.Next(0, 100);
                MessageBox.Show("I've chosen a new number. Let's play again.");
            }
            else if (guesses.Any())
            {
                var tempMsg = Math.Abs(guess - numberToGuess) <
                                Math.Abs(guesses.Last() - numberToGuess)
                    ? "You're getting warmer! :)"
                    : "You're getting colder! :(";
                MessageBox.Show($"{tempMsg}{Environment.NewLine}{incorrectMsg}");
                guesses.Add(guess);
            }
            else
            {
                MessageBox.Show($"Sorry, that's not it - try a {direction} number.");
                guesses.Add(guess);
            }
        }
        else
        {
            MessageBox.Show($"{textBox1.Text} is not a valid number - try again!");
        }
    }
