    retval.ForEach(i =>
            {
                if(retval.IndexOf(i) == percentage)
                   break;
                var periodOrdinal = _ce.Events
                    .Where(e => e.Attendees.Select(a => a.LicenseNumber).Contains(i.LicenseNumber))
                    .Select(e => e.Course.CertificationPeriod)
                    .OrderBy(p => p.StartDate)
                    .ToList()
                    .IndexOf(thePeriod) + 1;
                i.MetRequirements = determineIfCeMet(i.LicenseNumber, i.LicenseTypeCode, i.DateOfOriginalLicensure, periodOrdinal, thePeriod.Id, thePeriod.EndDate, thePeriod.Board);
                foreach (var field in properties)
                {
                    if (field.GetCustomAttribute<DataTypeAttribute>().DataType.Equals(DataType.Date))
                    {
                        var value = ((DateTime)field.GetValue(i));
                        worksheet.Cells[row, col].Style.Numberformat.Format = "MM/dd/yyyy";
                        worksheet.Cells[row, col].Formula = "=DATE(" + value.Year + "," + value.Month + "," + value.Day + ")";
                    }
                    else worksheet.SetValue(row, col, field.GetValue(i));
                    col++;
                }
                col = 1;
                row++;
            })
    
