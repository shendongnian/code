    public static void Cloud_OutLookMailStart(string EmailID, string password, string StoreFilePath)
    {
        try
        {
            LogHelper.LogMessage("<----- Cloud_OutLookMailStart Start ----->");
            DistributionReplyEntity ObjDistributionReplyEntity = new DistributionReplyEntity();
            ObjDistributionReplyEntity.OutLookEmailID = EmailID;
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP1);
            service.Credentials = new WebCredentials(EmailID, password);
            service.TraceEnabled = true;
            service.TraceFlags = TraceFlags.All;
            //service.Url = new Uri("https://IP/EWS/Exchange.asmx");
            service.AutodiscoverUrl(EmailID, RedirectionUrlValidationCallback);
            Microsoft.Exchange.WebServices.Data.Folder inbox = Microsoft.Exchange.WebServices.Data.Folder.Bind(service, WellKnownFolderName.Inbox);
            var items = service.FindItems(
            //Find Mails from Inbox of the given Mailbox
            new FolderId(WellKnownFolderName.Inbox, new Mailbox(EmailID)),
            //Filter criterion
            //  new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter[] {
            //  new SearchFilter.ContainsSubstring(ItemSchema.Subject, ConfigurationManager.AppSettings["ValidEmailIdentifier"].ToString()),
            new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false),
            //  }),
            //View Size as 15
            new ItemView(50));
            Console.WriteLine("Email {0}, unread Total Count{1}", EmailID, items.Count());
            foreach (Item item in items)
            {
                EmailMessage email = EmailMessage.Bind(service, new ItemId(item.Id.UniqueId.ToString()));
                if (!string.IsNullOrEmpty(email.Subject) && !string.IsNullOrWhiteSpace(email.Subject))
                {
                    var subject = email.Subject.ToString();
                    String[] arr = subject.Split(' ');
                    String firstWord = arr[0];
                    if (firstWord != "Undeliverable:")
                    {
                        //PROCESS EMAIL MESSAGE 
                        Console.WriteLine("Subject :{0}", email.Subject);
                        // TO
                        if (email.ToRecipients.Count > 0)
                        {
                            var propertySet = new PropertySet(ItemSchema.UniqueBody);
                            EmailMessage email2 = EmailMessage.Bind(service, email.Id, propertySet);
                            EmailMessage str = (EmailMessage)email2;
                            string str1 = str.UniqueBody.Text.ToString();
                            var EmailBody = ExtractReply(str1, "");
                            // string ReceiverEmail = email.ReceivedBy != null?email.ReceivedBy.Address:"" ;
                            // Email Body 
                            // var subjectEmail = ExtractReply(email.Body.ToString(), email.ReceivedBy.Address);
                            Console.WriteLine("Body {0}", EmailBody.ToString()); // Body
                            ObjDistributionReplyEntity.EmailBody = EmailBody;
                            string maltipleTo = string.Empty;
                            foreach (var toemailid in email.ToRecipients)
                            {
                                if (string.IsNullOrEmpty(maltipleTo))
                                {
                                    maltipleTo = toemailid.Address.ToString();
                                }
                                else
                                {
                                    maltipleTo += ";" + toemailid.Address.ToString();
                                }
                            }
                            Console.WriteLine("TO {0}", maltipleTo.ToString()); // TO
                            ObjDistributionReplyEntity.ReplyTO = maltipleTo.ToString();
                        }
                        // CC
                        if (email.CcRecipients.Count > 0)
                        {
                            string maltipleCC = string.Empty;
                            foreach (var ccemailid in email.CcRecipients)
                            {
                                if (string.IsNullOrEmpty(maltipleCC))
                                {
                                    maltipleCC = ccemailid.Address.ToString();
                                }
                                else
                                {
                                    maltipleCC += ";" + ccemailid.Address.ToString();
                                }
                            }
                            Console.WriteLine("CC {0}", maltipleCC.ToString());
                            ObjDistributionReplyEntity.ReplyCC = maltipleCC.ToString();
                        }
                        // Form
                        if (email.Sender.Address != "")
                        {
                            ObjDistributionReplyEntity.ReplyForm = email.Sender.Address;
                        }
                        Console.WriteLine("Subject {0}", email.Subject.ToString()); // Subject
                        ObjDistributionReplyEntity.Subject = email.Subject.ToString();
                        ObjDistributionReplyEntity.TransactionsID = 0;
                        ObjDistributionReplyEntity.IsProjectRelated = 0;
                        string Subject = email.Subject;
                       
                        ObjDistributionReplyEntity.ReceivedTime = email.DateTimeReceived;
                        var getSharePointFileUrl = GetAttachmentsFromEmail(service, item.Id, StoreFilePath, ObjDistributionReplyEntity.TransactionsID);
                      
                        email.IsRead = true;
                        email.Update(ConflictResolutionMode.AlwaysOverwrite);
                    }
                }
            }
            LogHelper.LogMessage("<----- Cloud_OutLookMailStart Start ----->");
        }
        catch (Exception ex)
        {
            LogHelper.LogError("OutLookMailStart -> Cloud_OutLookMailStart Exception");
            LogHelper.LogError("Exception Message :" + ex.Message);
            if (ex.InnerException != null)
            {
                LogHelper.LogError("Exception InnerException :" + ex.InnerException);
            }
            LogHelper.LogError("Exception StackTrace :" + ex.StackTrace);
            LogHelper.LogError("OutLookMailStart -> Cloud_OutLookMailStart Exception");
        }
    }
