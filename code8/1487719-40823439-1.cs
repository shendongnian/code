    public class QuestionElement
    {   
        public IWebElement Element { get; set; }
        
    }
    public class QuestionItem
    {
        public string QuestionID { get; set; }
        public list<QuestionElement> Elements;
    }
    public class QuestionItems
    {
        public SortedList<QuestionItem> Questions { get; set; }
    }
    public class PopulateQuestionItem()
    {
   
        public void AddQuestionResult(string questionID, QuestionItems questionItems, string colorItem)
        {
            IReadOnlyCollection<IWebElement> unfiltered = Driver.FindElements(By.CssSelector("*"));
            List<IWebElement> filtered = unfiltered.Where(f => f.GetCssValue("color") == colorItem).ToList();
            QuestionItem questionItem = new QuestionItem() { QuestionID = questionID };
        
            foreach (IWebElement element in filtered)
            {
                QuestionElement item = new QuestionElement()
                {
                    Element = element
                    
                };
                questionItem.ElementsAdd(item);
            }
            questionItems.Questions.Add(questionID, questionItem);
        }      
    
