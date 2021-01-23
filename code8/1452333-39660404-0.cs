    Response.Clear();
    Response.ContentType = "application/force-download";
    Response.AddHeader("content-disposition", "attachment; filename=publicationCitations.pdf");
    // This is the piece you're missing
    Response.BinaryWrite(p.generatePublicationCitationReport(pubIDs));   
    Response.End();
