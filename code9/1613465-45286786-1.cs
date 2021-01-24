       public void SetHyperlinkOnClipboard( string link, string description )
       {
          try
          {
             const string sContextStart = "<HTML><BODY><!--StartFragment -->";
             const string sContextEnd = "<!--EndFragment --></BODY></HTML>";
             const string m_sDescription = "Version:0.9" + Constants.vbCrLf + "StartHTML:aaaaaaaaaa" + Constants.vbCrLf + "EndHTML:bbbbbbbbbb" + Constants.vbCrLf + "StartFragment:cccccccccc" + Constants.vbCrLf + "EndFragment:dddddddddd" + Constants.vbCrLf;
    
             string sHtmlFragment = "<A HREF=" + Strings.Chr( 34 ) + link + Strings.Chr( 34 ) + ">" + description + "</A>";
    
             string sData = m_sDescription + sContextStart + sHtmlFragment + sContextEnd;
             sData = sData.Replace( "aaaaaaaaaa", m_sDescription.Length.ToString().PadLeft( 10, '0' ) );
             sData = sData.Replace( "bbbbbbbbbb", sData.Length.ToString().PadLeft( 10, '0' ) );
             sData = sData.Replace( "cccccccccc", ( m_sDescription + sContextStart ).Length.ToString().PadLeft( 10, '0' ) );
             sData = sData.Replace( "dddddddddd", ( m_sDescription + sContextStart + sHtmlFragment ).Length.ToString().PadLeft( 10, '0' ) );
             Clipboard.SetDataObject( new DataObject( DataFormats.Html, sData ), true );    
          }
          catch( Exception ex )
          {
          }
       }
