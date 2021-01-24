    private void button1_Click(object sender, EventArgs e)
    {
        int guess;
        if (int.TryParse(textBox1.Text, out guess))
        {
            if (guess == numberToGuess)
            {
                MessageBox.Show($"Good job! You got it in {guesses.Count + 1} tries!");
                guesses.Clear();
                numberToGuess = rnd.Next(0, 100);
                MessageBox.Show("I've chosen a new number. Let's play again.");
            }
            else
            {
                var direction = guess > numberToGuess ? "lower" : "higher";
                var message = $"Sorry, that's not it - try a {direction} number.";
                if (guesses.Any())
                {
                    var tempMsg = Math.Abs(guess - numberToGuess) <
                                  Math.Abs(guesses.Last() - numberToGuess)
                        ? "You're getting warmer! :)"
                        : "You're getting colder! :(";
                    message += $"{Environment.NewLine}{tempMsg}";
                }
                MessageBox.Show(message);
                guesses.Add(guess);
            }
        }
        else
        {
            MessageBox.Show($"{textBox1.Text} is not a valid number - try again!");
        }
    }
