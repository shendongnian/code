    public void randomq() //new question function... generating number, using it as index, putting it on lblQ
        {
            Random ran = new Random();
            questionno = ran.Next(20);
            label1.Text = questionno.ToString(); //debug
            label2.Text = gameClass.answers[questionno];//debug
            lblQ.Text = gameClass.questions[questionno];
            //Add this
            someStringAnswer = gameClass.answers[questionno];
            gameClass.questions.RemoveAt(questionno);
            //And this
            gameClass.answers.RemoveAt(questionno);
        }
