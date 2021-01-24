    public void SaveAnswers(List<questionModel.SAVEDANSWER> answers, int userid)
    {	
    	foreach(var item in answers){
    		using (MySqlConnection myconn = new MySqlConnection(cmn.connstring))
    		{
    			myconn.Open();
    			//do string interpolation of your query.
    			var myCmd = new MySqlCommand($@"INSERT INTO answer (QUESTIONID,USERANSWERID, USERID) VALUES ({item.QUESTIONID}, {item.ANSWERID},{userid})", myconn))
    			myCmd.CommandType = System.Data.CommandType.Text;
    			myCmd.ExecuteNonQuery();
    		}
    	}
    }
