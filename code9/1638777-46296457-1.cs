    public IActionResult Post([FromBody]myClass this_Is_Just_A_Name)
        {
            return Ok(this_Is_Just_A_Name);
        }
    public class myClass
    {
        public string[] myIDs { get; set; }
    }
