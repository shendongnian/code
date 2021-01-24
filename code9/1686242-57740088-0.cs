[Route("api/[controller]")]
    public class TestingController : Controller
    {
        [HttpPost("test")]
        public IActionResult Test(string pl)
        {
            if (pl == null)
            {
                return Ok();
            }
            PL plobj = JsonConvert.DeserializeObject<PL>(pl);
            //Random random = new Random(5);
            return Ok($"Test Test a=={plobj.a} b=={plobj.b}");
        }
    }
C# Class to serialize
 public class PL
    {
      public string a { get; set; }
      public  string b { get; set; }
    }
ReactJs Part
 var PL = {
            a: 1,
            b: 2
        };
        var data = new FormData();
        data.append("PL", JSON.stringify(PL));
        fetch('api/Testing/test',
            {
                method: "POST",
                body: data
            }).
            then(response => response.text())
            .then(data => {
                this.setState({ text: data, loading: false });
            });
I have to Note: Name in appending data in React part must be same AS name of variable in Core controller (ignoring case)
