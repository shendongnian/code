    String doc =
    @"<main>
    <Title title=""Hello World"" />
    <Content content=""bla bla bla... by <1% to ??? on other bla bla...."" />
    </main>";
    
    Int32 contentOpenStart = doc.IndexOf("<Content");
    Int32 contentAttribContentValueStart = doc.IndexOf("content=\"", contentOpenStart) + "content=\"".Length;
    Int32 contentAttibContentValueEnd    = doc.IndexOf("\"", contentAttribContentValueStart);
    String attributeValueOld = doc.Substring( contentAttribContentValueStart, contentAttibContentValueEnd );
    String attributeValueNew = System.Net.WebUtility.HtmlEncode( attributeValueOld );
    String doc2 = String.Concat(
        doc.Substring( 0, contentAttribContentValueStart );
        attributeValueNew,
        doc.Substring( contentAttibContentValueEnd );
    );
