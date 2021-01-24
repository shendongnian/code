    ws.Cells[1, 1].RichText.Add("first ");
    ws.Cells[1, 1].RichText.Add(" second");
    ws.Cells[1, 1].RichText.Text = ws.Cells[1, 1].RichText.Text.Insert(6, "Inserted");
    ws.Cells[1, 1].RichText.RemoveAt(ws.Cells[1, 1].RichText.Count - 1);
    Console.WriteLine(ws.Cells[1, 1].Text); 
