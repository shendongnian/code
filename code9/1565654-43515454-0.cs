        while (mReader.Read())
        {
            string sBrand = mReader.GetString(0);
            string sPhone = mReader.GetString(1);
            string sTec = mReader.GetString(2);
            lblBrand.Text = sBrand;
            lblPhone.Text = sPhone;
            lblTec.Text = sTec;
            int wdth = sTec.Length * 16; //you can put another value depending your charachter size. 
            lblTech.Size = new Size(wdth, 22);
         
        }
