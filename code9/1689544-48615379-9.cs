    public class QuizWord
    {
        public string Word { get; set; }
        public string WordMask { get; set; }
    }
    List<Quiz> QuizList = new List<Quiz>();
    private void button1_Click(object sender, EventArgs e)
    {
        QuizList.Add(new Quiz(lblSampleText1,
                     new List<QuizWord>  
                   { new QuizWord { Word = "jumped", WordMask = "umpe" }, 
                     new QuizWord { Word = "lazy", WordMask = "az" } }));
        QuizList.Add(new Quiz(lblSampleText2,
                     new List<QuizWord>  
                   { new QuizWord { Word = "dolor", WordMask = "olo" }, 
                     new QuizWord { Word = "elit", WordMask = "li" } }));
        QuizList.Add(new Quiz(lblSampleText3,
                     new List<QuizWord>  
                   { new QuizWord { Word = "Brown", WordMask = "row" }, 
                     new QuizWord { Word = "Foxes", WordMask = "oxe" }, 
                     new QuizWord { Word = "latinorum", WordMask = "atinoru" } }));
    }
