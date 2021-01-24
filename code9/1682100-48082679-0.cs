    public async Task<IActionResult> postObj([FromBody]EntireData data)
    {
        if (data.FirstClass != null)
        {
            //Do something
        }
        if (data.SecondClass != null)
        {
            //Do something
        }
    }
    public class EntireData
    {
        public FirstClass  firstClass { get; set; }
        public SecondClass secondClass { get; set; }
    }
