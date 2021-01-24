    public class MyController
    {
        public async Task<IActionResult> Test(string pod, string start, string end)
        {
            var r2s = new R2S.ServiceClient();
            R2S.Konstant[] kData = await r2s.GetKonstantListAsync(new string[] { "STATION" }, new string[] { pod }).Result;
            ViewData["start"] = start;
            ViewData["end"] = end;
            return View(kData);
        }
    }
