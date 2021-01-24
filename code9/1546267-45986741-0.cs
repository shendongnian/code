                using (DocX document = DocX.Load(AchivoPlantilla))
                {
                    Novacode.Image img = document.Images[0];
                    int i = 0;
                    foreach (Novacode.Bookmark bookmark in document.Bookmarks)
                    {
                        var bookmarks = document.Bookmarks[i].Name;
                        if (bookmarks == "varNombreEmpleado") //Compara la marca con la varible de base de datos
                        {
                            document.Bookmarks[bookmark.Name].SetText(TextBox1.Text);
       
                        }
                        i++;
                    }
                    document.SaveAs(docSalida);
                    Process.Start("WINWORD.EXE", "\"" + docSalida + "\"");
                }
