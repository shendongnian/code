    var result = new SelectList((from t in db.Customers
                                 let values = new[]
                                 {
                                        t.PersonalMail,
                                        t.BusinessMail,
                                        t.ContactName,
                                        t.BusinessName,
                                        t.Phone,
                                        t.DirectPhone
                                 }
                                 where values.Any(v => v.Contains(value))
                                 select t), "ID", "PersonalMail");
