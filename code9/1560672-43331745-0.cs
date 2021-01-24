        protected void Timer1_Tick(object sender, EventArgs e)
        {
            string s = (string)Session["Text"];
            Session["Text"] = String.Empty;
            bool hasNewText = !String.IsNullOrEmpty(s);
            if (hasNewText)
            {
                txtOut.Text += s;
                UpdatePanel1.Update();
            }
        }
