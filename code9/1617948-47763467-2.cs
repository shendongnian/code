        // the Results object in the json data is a JObject. It contains a JSON Array of Result objects
        JObject root = JObject.Parse(jsonData);
        JArray array = DumpItems(root, "results");
        List<Result> returnList = new List<Result>();
        foreach(var item in array)
        {
            Debug.WriteLine(item.ToString());
            Result _result = new Result();
            _result.ID = item["ID"].ToString();
            _result.Name = item["Name"].ToString();
            _result.Tags = item["Tags"].ToString();
            if(_result.Tags.Contains(tagSrc))
            {
                returnList.Add(_result);
            }
        }
        return returnList;
    }
