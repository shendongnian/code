    var ans = from A in TableA
              where A.ResourceID == 1
              from B in TableB.Where(b => b.DisplaySettingID == 1).Where(b => b.ElementNameID == A.TabNotesCodeID || b.ElementNameID == A.TabLabelCodeID).DefaultIfEmpty()
              select new {
                  SubSectionName = (B.CustomValue ?? A.TabLabelCodeID),
                  SubSectionNote = (B.CustomValue ?? A.TabNotesCodeID)
              };
