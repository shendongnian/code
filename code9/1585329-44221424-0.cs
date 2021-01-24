    public class MyData
    {
        public MyResult Result { get; set; }
    }
    public MyData GetData() { return new MyData(); }
    MyData data = GetData();
    return Json(data.Result);
