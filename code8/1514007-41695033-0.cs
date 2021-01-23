     var db = new QCDataClassesDataContext();
                    if (StartDate == DateTime.MinValue)
                        StartDate = DateTime.Now.AddDays(-30);
                    if (EndDate == DateTime.MinValue)
                        EndDate = DateTime.Now;  
    
    
      var objSelect = (from R in db.tblQCResults
                                                                                           join D in db.tblDeliverables on R.dbDeliverablesId equals D.dbId
                                                                                           join C in db.tblClients on D.dbClientId equals C.dbId
                                                                                           join E in db.tblEmployees on R.dbAssignedTo equals E.dbEmpId
                                                                                           where Convert.ToDateTime( R.dbQCDate).Date >= Convert.ToDateTime(StartDate).Date &&
                                                                                                 Convert.ToDateTime(R.dbQCDate).Date <= Convert.ToDateTime(EndDate).Date
                                                                                                 && R.dbQCBy == strEmpId
                                                                                           //&& R.dbStatus == false
                                                                                           orderby R.dbQCOn descending
                                                                                           select new
                                                                                           {
                                                                                               Client = C.dbClientName,
                                                                                               Deliverables = D.dbDeliverablesName,
                                                                                               EmployeeName = E.dbName,
                                                                                               TotalUploadedAccount = R.dbTotalUploadedAccount,
                                                                                               TotalQCAccount = R.dbTotalQCAccount,
                                                                                               Id = R.dbId,
                                                                                               QCOnDate = R.dbQCOn,
                                                                                               FileDate = R.dbFileDate,
                                                                                               Status = R.dbStatus,
                                                                                               EmpId = E.dbEmpId
                                                                                           }):
