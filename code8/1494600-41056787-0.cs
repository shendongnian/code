                        foreach (var ele in lst)
                            {
                                using (var srHtml = new StringReader(ele.Html))
                                {                               
                                                               
                                    if (ele.Oriantation == 1)
                                    {
                                        doc.SetPageSize(PageSize.A4.Rotate());
                                    }
                                    else
                                    {
                                        doc.SetPageSize(PageSize.A4);
                                    }
                                    doc.NewPage();
                                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, srHtml);
                                    doc.NewPage();
                                }
                            }
