    using (var quizFileReader = new System.IO.StreamReader("PhysQuestions.txt"))
    {
        Question question;
        int linesToRead = 4;
        string[] choices = new string[linesToRead];
        
        for (int i=0; i < linesToRead; i++)
        {
            choices[i] = await quizFileReader.ReadLineAsync();
        }
    }
