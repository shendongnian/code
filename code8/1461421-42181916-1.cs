    [WebMethod]
      public static List<Results> yourmethod(string text, string phone, string type)
            {
                List<Results> result = new List<Results>();
                DataTable question = getQuestions();
              if(question!=null){
                foreach (DataRow rw in autocomlete.Rows)
                {
                  result.Add(new Results { theQuestion = rw[0].ToString(), 
                  theCode = rw[3].ToString() });
                }
                }
                return result;
            }
