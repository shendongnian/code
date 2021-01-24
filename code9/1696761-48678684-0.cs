     while (DC.dbReader.Read())
                    {
                        Member member = new Member();
                        member.strEmailAddress = DC.dbReader["MemberEmail"].ToString();
        
                        Times time = new Times();
                        time.dtDateTime = (DateTime)DC.dbReader["DateTime"]; //Have date and time for individual user 
                        member.strDateTime = time.dtDateTime.ToString("d, dd-MM-yy, hh:mm tt"); //If you want 24H then use HH.
                        lstmember.Add(member);
                    }
        
           foreach(var item in lstmember)
                    {
                      EmailDispatcher.SendEmail(item.strEmailAddress, txt_subject.Text, HTMLEditor.Content.Replace("[Day, Date, Time]",item.strDateTime ));
                    }
