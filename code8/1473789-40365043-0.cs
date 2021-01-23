    // Add this to your using
    using System.Data.Entity;
    // Back to your example
    var count = db.tblItems.Count(i =>
                    DbFunctions.DiffDays(i.ExpireDate, DateTime.Now) <= i.AlertDays);
