        private void CardReaded(string cardnr)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtSearchPurse.Text = cardnr;
            });        
        }
