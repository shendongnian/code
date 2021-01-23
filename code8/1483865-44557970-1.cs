    if (Request.Cookies["CartCookie"] != null)
    {
            string objCartListString = Request.Cookies["CartCookie"].Value.ToString();
            string[] objCartListStringSplit = objCartListString.Split('|'); 
            foreach(string s in objCartListStringSplit)
            {
                string[] ss = s.Split(',');
                productName = ss[0];
                quantity = Convert.ToDouble(ss[1]);
                price = Convert.ToDecimal(ss[3]);
               .........                    
            }
    }
