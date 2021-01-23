    PathSpec path = new DepotPath("//depot/...");
    DateTimeVersion lowerTimeStamp = new DateTimeVersion(new DateTime(2016,12,06));
    DateTimeVersion upperTimeStamp = new DateTimeVersion(DateTime.Now);
    VersionSpec version = new VersionRange(lowerTimeStamp, upperTimeStamp);
    FileSpec[] fileSpecs = { new FileSpec(path, version) };
    
    ChangesCmdOptions changeListOptions = new ChangesCmdOptions(ChangesCmdFlags.FullDescription | ChangesCmdFlags.IncludeTime, null, 0, ChangeListStatus.None, null);
    IList<Changelist> changes = m_Repository.GetChangelists(changeListOptions, fileSpecs);
