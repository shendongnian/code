            var Depts = new Dictionary<string, AbsByReason>();
            foreach (var entry in TotalbeAbsencesDepartmentByReason)
            {
                AbsByReason abs;
                if (!Depts.TryGetValue(entry.Label, out abs))
                    Depts[entry.Label] = abs = new AbsByReason() { Label = entry.Label };
                switch (entry.Reason)
                {
                    case "AUT":
                        abs.Aut = entry.AbsenceHours.Value;
                        break;
                    case "NOAUT":
                        abs.NoAut = entry.AbsenceHours.Value;
                        break;
                    case "CM":
                        abs.CM = entry.AbsenceHours.Value;
                        break;
                }
            }
            var TotaleAbsDepartementByReason = Depts.Select(kvp => kvp.Value).ToList();
