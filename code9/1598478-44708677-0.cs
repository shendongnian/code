    var myRecord = TypeAdapter.Adapt<MyRecord>(myRecordViewModel);
    myRecord.DisplayName = myRecordViewModel.Name;
    // (1)
    var dbRecord = db.MyRecords.Include(x => x.Teams).FirstOrDefault(x => x.Id == myRecord.Id);
    // (2)
    db.Entry(dbRecord).CurrentValues.SetValues(myRecord);
    // (3)
    dbRecord.Teams = db.Teams.Where(a => myRecordViewModel .SelectedTeamIDs.Contains(a.TeamID)).ToList();
    // (4)
    db.SaveChanges();
