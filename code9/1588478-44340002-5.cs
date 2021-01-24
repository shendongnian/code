    public IList<DataModel> ReadEntrie(int id, string data_path)
    {
        int count = 0;
        CreateConfigFile();
        var fs = new FileStream(data_path, FileMode.Open);
        var sr = new StreamReader(fs);
        try
        {
            var list = new List<DataModel>();
            string temp = "";
            bool cond = true;
            while (cond == true)
            {
                if ((temp = sr.ReadLine()) == null)
                {
                    cond = false;
                    if (count == 0)
                        throw new Exception("Failed");
                }
                if (count > 0 && count == id)
                {
                    string[] stringSplit = temp.Split(',');
                    var item = new DataModel();
                    item.Name = stringSplit[0].Trim('"');
                    item.LastName = stringSplit[1].Trim('"');
                    item.Phone = stringSplit[2].Trim('"');
                    item.Mail = stringSplit[3].Trim('"');
                    item.Website = stringSplit[4].Trim('"');
                    // add item to list
                    list.Add(item);
                }
                count++;
            }
            return list;
        }
        catch
        {
            throw; // or do whatever you wish
        }
        finally
        {
            sr.Close();
            fs.Close();
        }
    }
