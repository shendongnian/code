        public static void ShowError(string message, Exception exp0)
        {
            Exception exp1 = exp0.InnerException;
            Exception exp2 = exp1 != null ? exp1.InnerException : null;
            Exception exp3 = exp2 != null ? exp2.InnerException : null;
          
            string mess = "unfortunately, no message is available.";
            string moremess = "";
            if (message != null)
            {
                mess = message;
                moremess = exp0.Message + "\n\n";
            }
            else if (exp0 != null)
            {
                mess = exp0.Message;
            }
            Exception exp = exp0.InnerException;
            while (exp != null)
            {
                moremess += exp.Message + "\n\n";
                exp = exp.InnerException;
            }
             MessageBox.Show(mess + Environment.NewLine + moremess);
        }
         
