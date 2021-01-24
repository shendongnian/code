    List<string> sPattern = new List<string> { "hi", "a painkiller" };
    public void SendQuestionToRobot()
    {
        if (string.IsNullOrEmpty(inputField.text) == false)
        {
            string answer = bot.getOutput(inputField.text);
            robotOutput.text = answer;
            inputField.text = "press enter to type";
            foreach (string s in sPattern)
            {
                if (Regex.IsMatch(answer, s, RegexOptions.IgnoreCase))
                {
                    controller.score += 5;
                    sPattern.Remove(s);
                    break;
                }
            }
        }
    }
