    TOK_ServiceLog fafa = new TOK_ServiceLog();
     fafa.Providers = sessionDetails.staff.Select(s => new TOK_ServiceLog_Provider()
                    {
                        StaffID = s.StaffID,
                        ServiceID = s.ServiceID,
                        AttendanceStatusID = s.AttendanceStatusID,
                        IsSubstituted = s.IsSubstituted,
                        SubstituteStaffID = s.SubstituteStaffID,
                        Comments = s.Comments
                    }).ToList();
