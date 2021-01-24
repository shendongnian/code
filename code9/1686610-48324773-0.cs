    var query = query.Where(o =>
                               new StringBuilder()
                               .Append(o.Data.General.Dossier)
                               .Append(o.Team.Name)
                               .Append(o.Data.General.MaintenancePlant)
                               .Append(o.Data.Location.BoxNumber)
                               .Append(o.Data.Location.City)
                               .Append(o.Data.Location.HouseNumber)
                               .Append(o.Data.Location.Zip.ToString())
                               .Append(o.Data.Location.Street)
                               .ToString()
                               .ToUpper()
                               .Contains(keyword));
