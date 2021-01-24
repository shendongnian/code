    MyResult r = JsonConvert.Deserialize<MyResult>(json);
    if (r.ErrorCode is JArray) {
       List<int> ints = (r.ErrorCode as JArray).ToObject<List<int>>();
       // ...
    } else {
       int i = Convert.ToInt32(r.ErrorCode);
       // ...
    }
