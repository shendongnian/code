    int i = 0;
    foreach( GridViewRow row in poGridview.Rows )
    {
        if( i % 3 == 0 && i > 0 )
        {
            pdfDoc.Add(p);
            pdfDoc.NewPage();
            p = <Create a new p>
        }
    
        i++;
    }
