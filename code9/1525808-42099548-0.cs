    public ActionResult Edit(Document document, bool sendEmail, string commentsTextBox)
        {
            if (ModelState.IsValid)
            {
                var documentInDB = docsDB.Documents.Single(d => d.Id == document.Id);
        
                docsDB.Entry(documentInDB).CurrentValues.SetValues(document);
        
                foreach (string propertyName in docsDB.Entry(documentInDB)
                                                .OriginalValues.PropertyNames)
                {
                    var OriginalValue = docsDB.Entry(documentInDB)
                                        .OriginalValues.GetValue<object>(propertyName);
                    var NewValue = docsDB.Entry(documentInDB)
                                   .CurrentValues.GetValue<object>(propertyName);
        
                    if (!OriginalValue.Equals(NewValue))
                    {
                        //capture the changes
                    }
                }
            }
        }
