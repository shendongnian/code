    object padlock = new object();
    
    foreach (EmailMessage m in findResultsSentItems)
    {
        em.Add(m);
    }
    lstMailContactDeatils.Clear();
    Parallel.ForEach(em,
            myItem =>
            {
                myItem.Load();
                foreach (EmailAddress e in myItem.ToRecipients)
                {
                    try
                    {
                        MailContactDeatils _MailContactDeatils1 = new MailContactDeatils();
                        _MailContactDeatils1.MailID = e.Address;
                        _MailContactDeatils1.DisplayName = e.Name;
                        _MailContactDeatils1.SentTime = myItem.DateTimeSent.ToString();
                    	//if(lstMailContactDeatils.Contains())
                    	lock(padlock) {
                        	lstMailContactDeatils.Add(_MailContactDeatils1);
                        }
                    }
                    catch (Exception e1) { exceptions.Enqueue(e1); }
                }
                foreach (EmailAddress e in myItem.CcRecipients)
                {
                    try
                    {
                        MailContactDeatils _MailContactDeatils2 = new MailContactDeatils();
                        _MailContactDeatils2.MailID = e.Address;
                        _MailContactDeatils2.DisplayName = e.Name;
                        _MailContactDeatils2.SentTime = myItem.DateTimeSent.ToString();
                        lock(padlock) {
                            lstMailContactDeatils.Add(_MailContactDeatils2);
                        }
                    }
                    catch (Exception e2) { exceptions.Enqueue(e2); }
                }
            });
