    object attachment;
        List<string> recipients = new List<string>();
        BackgroundWorker emailer = new BackgroundWorker();
        public void startSending()
        {
            emailer.DoWork += sendEmails;
            emailer.RunWorkerAsync();
        }
        private void sendEmails(object sender, DoWorkEventArgs e)
        {
            foreach(string recipient in recipients)
            {
                sendEmail(recipient, attachment);
            }
        }
