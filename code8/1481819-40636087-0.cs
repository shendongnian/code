    public class ControllerHelper
    {
        public void DeleteChain(int? chainId) {
            using (var db = new UranusContext()) {
                var chain = db.Chains.Include(c => c.Sheets)
                    .SingleOrDefault(c => c.ChainId == chainId);
                // Removes sheets (children)
                foreach (var sheet in chain.Sheets.ToList()) {
                    DeleteSheet(db, sheet);
                }
                db.Chains.Remove(chain);
                db.SaveChanges();
            }
        }
        public void DeleteSheet(int? sheetId) {
            using (var db = new UranusContext()) {
                var sheet = db.Sheets.Include(s => s.FileDetails)
                    .Include(s => s.SheetsCounties)
                    .SingleOrDefault(s => s.SheetId == sheetId);
                DeleteSheet(db, sheet);
                db.SaveChanges();
            }
        }
        private void DeleteSheet(UranusContext db, Sheet sheet) {
            foreach (var fileDetails in sheet.FileDetails.ToList()) {
                db.FileDetails.Remove(fileDetails);
            }
            foreach (var sheetsCounties in sheet.SheetsCounties.ToList()) {
                db.SheetsCounties.Remove(sheetsCounties);
            }
            db.Sheets.Remove(sheet);
        }
    }
