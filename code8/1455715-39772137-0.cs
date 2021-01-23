            while (!csvReader.EndOfStream)
            {
                try
                {
                    string abc = csvReader.ReadLine();
                    var item = abc.Split(',');
                    if (item != null)
                    {
                        listTrans.Add(new Translation()
                        {
                            KeyName = item[0],
                            Value = item[3],
                            State = (int)EnumState.Created,
                            ApplicationLanguageId = appId,
                            CreatedBy = User.Identity.Name,
                            CreatedOn = DateTime.UtcNow
                        });
                    }
                }
                catch (Exception ex)
                {
                }
            }
