     NameValueCollection data = new NameValueCollection();
    data.Add("PaReq", "eJxdUl1P4zAQfOdXRHm/+KNO2yDXiEIRfeAEpXDiMefsUUskKU5ybfn1t07rc0oURd6Z8e5mduXV
    vvyI/oJtTF3NYpbQOIJK14Wp3mfxy/ruxzS+UhdyvbEAt8+gOwvqIorkAzRN/g6RKfDWeCwYz0Qa
    OwrJx+sVfB7PGJ2yK0yecEl86OkH+iJvQXHKJhQ/EZtephRf
    SXp8YFrpulbr1VvEEo78CQiKrevl+ogypxgCAys6a3EHDioTGXrhoyCA/bauAO+gVf/Pg36h0REJ
    nny3QN7cn81atzi1MR+NGJ+K1I27R87qGZwGH1PRFzRhNJL4ZFjHb50bQ7+duLjkfHP/AT7Qy6g=");
    data.Add("TermUrl", "https://sanalpos.teb.com.tr/fim/est3Dgate?msgid=16945");
    data.Add("MD", "402591:30D0FEDACD3047305C8E24EBC3739AC3E87C8:4273:##400644452");
    RedirectAndPOST(this.Page, "https://acs.bkm.com.tr/mdpayacs/pareq", data);
        /// <summary>
        /// POST data and Redirect to the specified url using the specified page.
        /// </summary>
        /// <param name="page">The page which will be the referrer page.</param>
        /// <param name="destinationUrl">The destination Url to which
        /// the post and redirection is occuring.</param>
        /// <param name="data">The data should be posted.</param>
        /// <Author>Samer Abu Rabie</Author>
        public static void RedirectAndPOST(Page page, string destinationUrl,
                                           NameValueCollection data)
        {
            //Prepare the Posting form
            string strForm = PreparePOSTForm(destinationUrl, data);
            //Add a literal control the specified page holding 
            //the Post Form, this is to submit the Posting form with the request.
            page.Controls.Add(new LiteralControl(strForm));
        }
        /// <summary>
        /// This method prepares an Html form which holds all data
        /// in hidden field in the addetion to form submitting script.
        /// </summary>
        /// <param name="url">The destination Url to which the post and redirection
        /// will occur, the Url can be in the same App or ouside the App.</param>
        /// <param name="data">A collection of data that
        /// will be posted to the destination Url.</param>
        /// <returns>Returns a string representation of the Posting form.</returns>
        /// <Author>Samer Abu Rabie</Author>
        private static String PreparePOSTForm(string url, NameValueCollection data)
        {
            //Set a name for the form
            string formID = "PostForm";
            //Build the form using the specified data to be posted.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" +
                           formID + "\" action=\"" + url +
                           "\" method=\"POST\">");
            foreach (string key in data)
            {
                strForm.Append("<input type=\"hidden\" name=\"" + key +
                               "\" value=\"" + data[key] + "\">");
            }
            strForm.Append("</form>");
            //Build the JavaScript which will do the Posting operation.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language='javascript'>");
            strScript.Append("var v" + formID + " = document." +
                             formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");
            //Return the form and the script concatenated.
            //(The order is important, Form then JavaScript)
            return strForm.ToString() + strScript.ToString();
        }
