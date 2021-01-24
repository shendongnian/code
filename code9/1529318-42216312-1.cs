    foreach( string s in txtInstagramUrls.Lines ) {
       try {
          if( s.Contains( "something" ) ) {
             using( WebClient wc = new WebClient() ) {
                Match m = Regex.Match( wc.DownloadString( s ), "(?<=og:image\" content=\")(.*)(?=\" />)", RegexOptions.IgnoreCase );
                if( m.Success ) {
                   txtConvertedUrls.Text += m.Groups[ 1 ].Value + Environment.NewLine;
                }
             }
          }
       }
       catch( WebException we ) {
          if( we.Status == WebExceptionStatus.ProtocolError && we.Response != null ) {
             var resp = ( HttpWebResponse ) we.Response;
             if( resp.StatusCode == HttpStatusCode.NotFound ) {
                continue;
             }
          }
          throw;
       }
    
    }
