            string htmlEnc = HttpUtility.HtmlEncode(row["Description"].ToString());
            string htmlDec = HttpUtility.HtmlDecode(row["Description"].ToString());
            string noHTML = Regex.Replace(htmlDec, @"<[^>]+>|&nbsp;", "").Trim(); 
            
            string noHTMLNormalised = Regex.Replace(noHTML, @"\s{2,}", " ");
            ws.Cell("C" + rowIndex).Value = noHTMLNormalised;
