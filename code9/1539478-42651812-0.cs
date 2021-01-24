    using (WebClientEx wc = new WebClientEx())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string HTMLPage = wc.DownloadString(CREAT_TICKET_URL);
            string form_build_id    = SearchValue(HTMLPage, "<input type=\"hidden\" name=\"form_build_id\"", "value=\"", "\"  />");
            string form_token       = SearchValue(HTMLPage, "<input type=\"hidden\" name=\"form_token\"", "value=\"", "\"  />");
            string myParameters = "macchina=" + cmacExtID + "&utente=" + custExtID + "&oggetto=" + Title + "&body=" + Note + "&op=Conferma&form_build_id=" + form_build_id + "&form_token=" + form_token + "&form_id=app_form_new_ticket";
    
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string HtmlResult = wc.UploadString(CREAT_TICKET_URL, myParameters);
        }
