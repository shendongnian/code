        public void CallButtonFromAnotherRibbon()
        {
            try
            {
                SendKeys.Send("%");
                SendKeys.Send("Y");
                SendKeys.Send("2");
                SendKeys.Send("%");
                SendKeys.Send("Y");
                SendKeys.Send("7");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
