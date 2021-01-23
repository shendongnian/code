                    System.Uri uri = new System.Uri("your url path");
                    using (SvnClient client = new SvnClient())
                    {
                        SvnUriTarget from = new SvnUriTarget(uri);
                        // To Get the Latest Revision on the Required SVN Folder
                        SvnInfoEventArgs info;
                        client.GetInfo(uri, out info);
                        SvnRevisionRange range = new SvnRevisionRange(info.Revision - 10, info.Revision);   // Get Diff for 10 revisions from Head revision
                        System.IO.MemoryStream stream = new System.IO.MemoryStream();
                        if (client.Diff(from, range, stream))
                        {
                            stream.Position = 0;    //reset the stream position to zero, as the stream position returned from Diff method is at the end.
                            System.IO.File.AppendAllText(@"C:\diffFile.patch", new System.IO.StreamReader(stream).ReadToEnd());
                        }
                        stream.Close();
                    }
