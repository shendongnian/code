      private void Bksp_tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                this.Resultt.Text = "worked"
                                + this.Bksp_isdown.ToString() + this.Inputt.SelectionStart.ToString();
                while (true)
                {
                    this.intt = this.intt + 100;
                    this.Backspace();
                }
            }
            catch(Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long);
            }
        }
