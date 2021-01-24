     public void SaveAnswers(List<questionModel.SAVEDANSWER> answers, int userid)
        {
            StringBuilder query = new StringBuilder("INSERT INTO answer (QUESTIONID,USERANSWERID, USERID) VALUES";
    
            using (MySqlConnection myconn = new MySqlConnection(cmn.connstring))
            {
                List<String> Rows = new List<String>();
                for (int i = 0; i <= answers.Count - 1; i++)
                {
                  Rows.Add(string.Format("({0},{1},{2})", (answers[i].QUESTIONID), (answers[i].ANSWERID),(answers[i].userId)));
                }
            query.Append(string.Join(",", Rows));
            query.Append(";");
            myconn.Open();
            using (MySqlCommand myCmd = new MySqlCommand(query.ToString(), myconn))
            {
                myCmd.CommandType = CommandType.Text;
                myCmd.ExecuteNonQuery();
            }
            myconn.Close();
            }
        }
