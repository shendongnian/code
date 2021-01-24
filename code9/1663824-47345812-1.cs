    public static void KvYQ()
                {
                    List<Team> modifiedTeams = new List<Team>() {
                        new Team() {
                            Id="T1"
                            ,Driver=new Driver() {
                                DriverId="D2"
                            }
                            ,Codriver=new Driver() {
                                DriverId="C1"
                            }
                        }
                        ,new Team() {
                            Id="T2"
                            ,Driver=new Driver() {
                                DriverId="D1"
                            }
                        }
                    };
    
                    List<Team> allTeams = new List<Team>() {
                        new Team() {
                            Id="T1"
                            ,Driver=new Driver() {
                                DriverId="D1"
                            }
                            ,Codriver=new Driver() {
                                DriverId="C1"
                            }
                        }
                        ,new Team() {
                            Id="T2"
                            ,Driver=new Driver() {
                                DriverId="D2"
                            }
                            ,Codriver=new Driver() {
                                DriverId="C2"
                            }
                        }
                    };    
                                   
                    var driverdetails = modifiedTeams.Select(x => new Team()
                    {
                        Driver = x.Driver,
                        Codriver = x.Codriver
                        
                    });
    
                    foreach (var item in driverdetails)
                    {
                        Driver d = (item.Driver == null) ? allTeams.Select(x => x.Driver).FirstOrDefault() : item.Driver;
                        Driver c = (item.Codriver == null) ? allTeams.Select(x => x.Codriver).FirstOrDefault() : item.Codriver;
                        Console.WriteLine(d.DriverId + " " + c.DriverId);
                        //{D2,C1}
                        //{D1,C1}
                    }
    
    
                }
