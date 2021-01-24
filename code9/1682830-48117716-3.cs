    [HttpPost]
    public ActionResult MCQ(String McqAnswerListArray) {
    	string[] Jsonn = mcm.McqAnswerListArray.Split(',');
                       
        for (int i = 0; i < Jsonn.Count(); i++) {
            string s = Jsonn[i];
            string[] obj = s.Split(':');
            string strqid = obj[0].ToString();
            int qid = Convert.ToInt32(strqid.Substring(3, strqid.Length - 3));//Get Question Group Number
            int Answer = Convert.ToInt32(obj[1].ToString());//Get Group Answer
    		//You Can save Your answer bellow
    	}
    }
