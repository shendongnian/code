    //Iterate Word.Application.Documents collection and get the specified Document.
                    // Document to be closed: MathFomular.docx
                    // There're multiple document open
                    foreach (Word.Document doc in wordApp.Documents)
                    {
                        if (string.Equals(doc.Name, "MathFomular.docx"))
                        {
                            doc.Close(false, WdOriginalFormat.wdPromptUser);
                            Console.WriteLine("Document closed.");
                            break;  // no document with same name open at a moment
                        }
                        else
                        {
                            // continue;
                        }
                    }
