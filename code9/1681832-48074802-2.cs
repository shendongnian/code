    public class ReaderController : ApiController
    {
        [ResponseType(typeof(string))]
        public IHttpActionResult Get(String FileName)
        {
            string fileName = FileName;
            string path = "C:\\Users\\attsuap1\\Desktop\\" + fileName;
            string result = File.ReadAllText(path);
            result = result.Replace("\r\n", "");
            result = result.Replace("\t", " ");
            var resultDTO = JsonConvert.DeserializeObject(result);
            return Ok(resultDTO);
        }
    }
