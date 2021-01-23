    public class PrinterController : ApiController
    {
            [HttpGet]
            public IHttpActionResult Get()
            {
                var result = System.Drawing.Printing.PrinterSettings.InstalledPrinters;
                return Ok(result);
            }
    }
