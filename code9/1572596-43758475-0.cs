    public class SmsController : Controller {
        private IDatabaseManager _dbManager;
        public SmsController(IDatabaseManager databaseManager) {
            this._dbManager = databaseManager;
        }
        public ActionResult CreateSms(SendSMSViewModel tblSend) {
            if (ModelState.IsValid) {
                if (_dbManager.SendSMS(tblSend.CellNumber, tblSend.Message, User.Identity.Name)) {
                    TempData["Success"] = "Message was successfully sent";
                } else {
                    TempData["Error"] = "An error occured while sending the message";
                }
            }
            return RedirectToAction("CreateSms");
        }
    }
