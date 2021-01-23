    [Given(@"button (.*) (is .*)")]
            public void ThenButtonIsTransformation(string buttonColor, bool status)
            {
                string color = buttonColor;
                bool value = status;
                Console.Write("Button color is: {0} and value is: {1}", color, value);
            }
 
    [StepArgumentTransformation(@"is (\w+)")]
            public bool ProduceBoolValue(string status)
            {
                if (status.ToLower().Equals("true"))
                    return true;
                if (status.ToLower().Equals("false"))
                    return false;
                return false;
            }
