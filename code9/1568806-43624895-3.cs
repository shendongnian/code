    public class YourClass
    {
        private readonly SQLConnectionHelper _sql = new SQLConnectionHelper(@"Data Source=knowledge.db;Version=3");
        public void MultiChoiceLight()
        {
            string query1 = $"UPDATE testOrder SET question='{QuestionsFromDb.question}', choice1='{QuestionsFromDb.choice1}" +
            $"', choice2='{QuestionsFromDb.choice2}', choice3='{QuestionsFromDb.choice3}', choice4='{QuestionsFromDb.choice4}' " +
            $"WHERE qid={QuestionsFromDb.b}";
            int result = _sql.ConnectExecuteNonQuery(query1);
        }
        public void MultiChoiceButtonNext()
        {
            _sql.ConnectExecuteReader($"SELECT * FROM testOrder WHERE qid={qid}", r => {
                // process your reader here, outside of this lambda connection will be closed
            });
        }
    }
