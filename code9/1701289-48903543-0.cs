    private List<bool> results = new ArrayList<bool>();// you can change this to something better like a Class that contains question ID, result, time used to response....
    public void AnswerButtonClicked(bool isCorrect)
    {
        results.Add(isCorrect); // the position in the array corresponts to the question. For example: Question 1 -> results[0]...Question2 -> results[1]
        if (isCorrect)
        {
            Debug.Log("Your Answer is Correct");
            playerScore += currentRoundData.pointsAddedForCorrectAnswer;                    // If the AnswerButton that was clicked was the correct answer, add points
            scoreDisplay.text = playerScore.ToString();
            
        }
    
        if (qNumber < questionPool.Length - 1)                                            // If there are more questions, show the next question
        {
            qNumber++;
            ShowQuestion();
        }
        else                                                                                // If there are no more questions, the round ends
        {
            EndRound();
        }
    }
