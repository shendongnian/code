    Document doc = new Document(MyDir + "Sample.docx");
    Table table = (Table)doc.GetChild(NodeType.Table, 0, true);
    foreach (Paragraph par in table.LastRow.LastCell.Paragraphs)
    {  
        foreach (Run run in par.Runs) //par - it's Paragraph in Cells
        {
            if (run.IsInsertRevision || run.IsDeleteRevision) //check revisions (in TrackChange)
            {
                Console.WriteLine(run.Font.Shading.BackgroundPatternColor);
            }
        }
    }
