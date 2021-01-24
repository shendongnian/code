    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [Route("imageExample")]
        public IActionResult ImageExample()
        {
            if (Request.Form != null && Request.Form.Files.Any())
            {
                foreach (var formFile in Request.Form.Files)
                {
                    var filePath = Path.Combine("c:\\temp\\", formFile.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        formFile.CopyTo(fileStream); //saving file to file system
                    }
                }
            }
            return Redirect("/somewhere-else");
        }
    }
