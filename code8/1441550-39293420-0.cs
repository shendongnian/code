    var backupParts = FileHandler.GetAllBackupPackages()
        .Select((fileName, index) => new XElement("backup_part",
            new XAttribute("id", index + 1),
            new XAttribute("mboxId", "?"),
            new XAttribute("uid", "?"),
            FileHandler.GenerateFileChecksum(fileName)));
    var backup = new XElement("backup",
        new XAttribute("id", backupId),
        new XAttribute("totalParts", totalBackupParts),
        new XAttribute("date", backupDate),
        new XAttribute("name", backupName),
        new XAttribute("description", backupDescription),
        backupParts);
    var doc = XDocument.Load(Program.defaultBackupFile);
        
    doc.Root.Add(backup);
    doc.Save(Program.defaultBackupFile)
