    public class MyController : Controller {
        public async Task<ActionResult> Post(string url, StringContent data, Dictionary<string, string> headers) {
            using (var client = new HttpClient()) {
                var response = await client.PostAsync(url, data);
                var result = await response.Content.ReadAsStringAsync();
                
                return Json(new { HttpStatusCode = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
            }
        }    
    }
