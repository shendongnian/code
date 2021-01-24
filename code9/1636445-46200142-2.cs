    public class MyPerformerController: ApiController {
        [HttpPut("update/{myPath}")]
        public IActionResult PerformUpdate(string myPath, [FromBody]MyDataTransferObject myDto) {
    
        }
    }
