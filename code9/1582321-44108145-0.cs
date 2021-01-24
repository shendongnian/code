    using System;
    
    using UIKit;
    
    namespace SingleViewApp
    {
        public partial class ViewController : UIViewController
        {
            int count = 0;
            int countFrom = 8;
            int guess;
            bool run = false;
            int number =0;
    
        public ViewController(IntPtr handle) : base(handle)
        {
            Random random = new Random();
            number = random.Next(1, 1001);
        }
    
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
    
            textView.Text = $"Can you guess my number in {countFrom} or less tries? Number: ";
    
        }
    
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    
    
        partial void EnterButton_TouchUpInside(UIButton sender)
        {
            try
            {
                guess = Convert.ToInt32(guessInput.Text);
                if (guess == number && count <= 8)
                {
                    textView.Text = $"Congrats, you won! Guessed in {count + 1} guesses.";
                }
                else if (guess != number && count >= 8)
                {
                    textView.Text = $"You lose! The number was {number}.";
                }
                else if (guess == (number - 25))
                {
                    textView.Text = "A hint: The number is higher than that!";
                }
                else if (guess == (number + 25))
                {
                    textView.Text = "A hint: The number is lower than that!";
                }
                else if (guess <= (number - 50))
                {
                    textView.Text = "A hint: The number is higher than that!";
                }
                else if (guess == (number + 50))
                {
                    textView.Text = "A hint: The number is lower than that!";
                }
                else if (guess == (number - 75))
                {
                    textView.Text = "A hint: The number is higher than that!";
                }
                else if (guess == (number + 75))
                {
                    textView.Text = "A hint: The number is lower than that!";
                }
                else if (guess == (number - 100))
                {
                    textView.Text = "A hint: The number is higher than that!";
                }
                else if (guess == (number + 100))
                {
                    textView.Text = "A hint: The number is lower than that!";
                }
                else if (guess >= (number - 2) && guess <= (number + 2))
                {
                    textView.Text = "You're practically there (2) !";
                }
                else if (guess >= (number - 5) && guess <= (number + 5))
                {
                    textView.Text = "You're very close (5) !";
                }
                else if (guess >= (number - 13) && guess <= (number + 13))
                {
                    textView.Text = "You are close (13) !";
                }
                else if (guess >= (number - 25) && guess <= (number + 25))
                {
                    textView.Text = "It's warmer.";
                }
                else if (guess >= (number - 50) && guess <= (number + 50))
                {
                    textView.Text = "It's warm.";
                }
                else if (guess >= (number - 75) && guess <= (number + 75))
                {
                    textView.Text = "It's not too far anymore!";
                }
                else if (guess >= (number - 100) && guess <= (number + 100))
                {
                    textView.Text = "You are not quite there!";
                }
                else if (guess <= (number - 150))
                {
                    textView.Text = "You are too low!";
                }
                else if (guess >= (number + 150))
                {
                    textView.Text = "You are too high!";
                }
                else if (guess > number)
                {
                    textView.Text = "It's lower.";
                }
                else if (guess < number)
                {
                    textView.Text = "It's higher.";
                }
                count++;
                countFrom--;
            }
            catch (FormatException e)
            {
                textView.Text = "Wrong input!";
            }
        }
    }
