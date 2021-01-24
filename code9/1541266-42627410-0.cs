            string  sj;
         
        void calculator ()
        {
            if (String.IsNullOrEmpty(mtb_SALAIR02.Text)) return;
            mtb_SALAIR02.Text = string.Format("{0:#,##0.00}", double.Parse(mtb_SALAIR02.Text));
            sj = (Double.Parse(mtb_SALAIR02.Text, CultureInfo.CurrentCulture) / 30).ToString();
            mtb_SJ02.Text = string.Format("{0:#,##0.00}", double.Parse(sj));
        }
