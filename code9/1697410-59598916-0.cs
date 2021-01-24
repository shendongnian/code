 public IActionResult GetFileDirect(string f)
{
   var path = Path.Combine(Defaults.StorageLocation, f);
   var res = File(System.IO.File.OpenRead(path), "video/mp4");
   res.EnableRangeProcessing = true;
   return res;
} 
This allowed for seeking in the browser.
