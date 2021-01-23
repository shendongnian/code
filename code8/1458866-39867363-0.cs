    private IEnumerable<CandidatesDTO> FileToDto(byte[] file)
                {
                    System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                    IEnumerable<CandidatesDTO> query = null;
                    string[] separators = { ",", ".", "!", "?", ";", ":", " " };
                    try
                    {
                        var str = enc.GetString(file);
                        query = from line in str.split("\r\n")
                                let data = str.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                                select new CandidatesDTO
                                {
                                    Id = Int32.Parse(data[0]),
                                    Name = data[1],
                                    DOB = DateTime.Parse(data[2], CultureInfo.InvariantCulture),
                                    Phone = data[3],
                                    Email = data[4]
                                };
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return query;
                }
