    if (!string.IsNullOrEmpty(fromDate))
                {
                    var Frodate = Convert.ToDateTime(fromDate).Date;
                    candidateList = candidateList.FindAll(x => DbFunctions.TruncateTime(x.CandidateRegistrationDate).Date >= date);
                }
                if (!string.IsNullOrEmpty(toDate))
                {
                    var tdate = Convert.ToDateTime(fromDate).Date;
                    candidateList = candidateList.FindAll(x => DbFunctions.TruncateTime(x.CandidateRegistrationDate) <= tdate);
                } 
