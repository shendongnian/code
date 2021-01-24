    var sent = SendMsg.Select(s => new {
        Id = s.Id,
        Name = s.Name,
        EmailST = (s.EmailST == "S"? (System.Drawing.Image)Properties.Resources.IMAGE8
                                   : (System.Drawing.Image)Properties.Resources.IMAGE9)
    }).ToList();
    gvSent.DataSource = null;
    gvSent.DataSource = sent;
