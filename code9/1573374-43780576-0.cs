    public static EmailSenderContext {
        private static object _locker = new object();
        public static bool CanSend = true;
        public static bool ChangeSendState(bool canSend) {
            lock(_locker) {
                CanSend = canSend;
            }
        }
    }
    public class MyController {
        [HttpGet]
        public void SendMail()
        {
            var emails = db.Emails.ToList();            
            foreach (var email in emails)
            {
                //code for sending mail here...
    
                if (!EmailSenderContext.CanSend)
                    break;
            }
        }
        [HttpGet]
        public void StopMail()
        {
            EmailSenderContext.ChangeSendState(false);
        }
    }
