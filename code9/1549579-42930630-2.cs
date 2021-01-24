    var query= context.Organizations.SelectMany(o=>context.EnrolmentTypes
                                    .SelectMany(t=>context.Users
                                    .Select(u=>new OrganizationEnrolment {
                                                       EnrolmentType = t,
                                                       Organization = o,
                                                        User = u
                                                      })));
               
