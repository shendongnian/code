     [HttpPost]
                public ActionResult EmailCampaignProcess(FormCollection collection)
                {
                    //var userType = Request["userType"];
                    //var emailContent = Request["emailContent"];
                    //SendSimpleMessage();
                    //ViewBag.Message = "Hello " + Request["userType"];
        
        
                    var Emails = db.Users.Where(d => d.Subscriptions.Any(x => x.Status == true)).Select(u => u.Email).ToArray();
        
     foreach (string SingleEmail in Emails) {
        
                        SendSimpleMessage(SingleEmail);
        
                    }
             // Or if you are not sure about the outcome type you can use the var keyword like below
        
                    foreach (var SingleEmail in Emails) {
        
                        SendSimpleMessage(SingleEmail);
        
                    }
        
                }
