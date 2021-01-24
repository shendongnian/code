                           foreach (JsonValue groupValue1 in jsonData1)
                            {
                                JsonObject groupObject2 = groupValue1.GetObject();
                                string title = groupObject2["judul"].GetString();
                                string cover = groupObject2["cover"].GetString();
                                string size = groupObject2["formated_size"].GetString();
                                Buku file1 = new Buku();
                                file1.Judul = title;
                                file1.Cover = cover;
                                file1.Size = size;
                                datasource.Add(file1);
                            }
            for (var i = 0; i < datasource.Count; i++)
            {
                if (datasource[i].Size == 0)
                {
                    datasource.RemoveAt(i);
                    i--;
                }
            }
