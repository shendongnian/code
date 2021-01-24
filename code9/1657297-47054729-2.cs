     SMSNotifier notifier = new SMSNotifier();
     var doctorsToNotify = db.AspNetUsers.Where(x => x.ReceiveSMS == true && x.AspNetUserRoles.Any(y => y.RoleId == "1")).ToList();
    
                foreach (AspNetUser dr in doctorsToNotify)
                {
                    await notifier.SendWaitingPatientNotification(existingUser, dr.Phone);
                }
