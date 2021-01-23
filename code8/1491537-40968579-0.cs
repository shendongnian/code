         int cnt_match = ds.Tables[0].Select("Question_type = Matching").Length; //Count the numbers of row which having question matching .
                int count = 0;
                int min = 0;
                int max = 0;
    //Make a list of random number 
                List<int> list_rno = new List<int>(); //random number list array 
                if (cnt_match > 0)
                {
                    //- shuffling the match B ---> Start
                    Random rand = new Random();
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        string que_type = ds.Tables[0].Rows[i]["Question_Type"].ToString();
                        if (que_type == "Matching") 
                        {
                            if (count == 0)
                            {
                                max = i + cnt_match;     //Last row of dataset of matching question 
                                min = i;  //First row no of Dataset of matching question 
                                list_rno = GetRandomNumbers(min, max);
                            }
                            if (count < cnt_match)
                            {
                                //swapping the value <--start-->
                                string temp = ds.Tables[0].Rows[i]["MatchB"].ToString();
                                ds.Tables[0].Rows[i]["MatchB"] = ds.Tables[0].Rows[list_rno[count]]["MatchB"].ToString();
                                ds.Tables[0].Rows[list_rno[count]]["MatchB"] = temp;
                                //swaping the value <--end-->
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
