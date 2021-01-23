    I found out other way to do it. I think it's very simple and well constructed ! 
    using (var oldDb = new oldBAEntity())
            {
                using (var newDb = new NewDbContextEntities())
                {
                    var queryHospitals_ = oldDb.N_Hospital_;
                    var queryHospitals = oldDb.N_Hospital;
                    List<Hospital> listHospital = new List<Hospital>();
                    var joinResult = (from t1 in queryHospitals_
                                      join t2 in queryHospitals on t1.IdCode equals t2.IdCode
                                      select new
                                      {
                                          t1.IdCode,
                                          t1.Value,
                                          t1.Address,
                                          t2.IdSettlement
                                      });
                    foreach (var sourceObj in joinResult)
                    {
                        Hospital targetObj = new Hospital();
                        targetObj.ID = (int)sourceObj.IdCode;
                        targetObj.HospitalName = sourceObj.Value;
                        targetObj.HospitalAddress = sourceObj.Address;
                        targetObj.SettlementId = (int)sourceObj.IdSettlement;
                        listHospital.Add(targetObj);
                    }
                    newDb.Hospitals.AddRange(listHospital);
                    newDb.SaveChanges();
                }
            }
