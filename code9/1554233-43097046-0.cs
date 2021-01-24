        private void LogAddInfo(string line, LogType lt)
        {
            if (lvLog.InvokeRequired)
            {
               lvLog.Invoke((MethodInvoker)delegate ()
               {
                   this.LogAddInfo(line, lt);
               });
            }
            else
            {
                // code that adds item to listView (in this case $o)
                lvLog.Items.Add(new ListViewItem(DateTime.Now.ToString(" HH:mm:ss ") + line, (int)lt));
            }
        }
