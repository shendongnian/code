    var MyLinkButton = new LinkButton();
    MyLinkButton.ID = "lbl" + counter++;
    MyLinkButton.Text = dritem["UpDocumentName"];
    MyLinkButton.CommandArgument = dritem["DocumentName"];
    MyLinkButton.Click += ViewDocument;
    divTitle.Controls.Add(MyLinkButton);
