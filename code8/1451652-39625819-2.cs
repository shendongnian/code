       Task.Factory.StartNew(() =>
            {
                using (PersonDBEntities db = new PersonDBEntities())
                {
                    try
                    {
                        persons = (from pers in db.Person
                                   join bu in db.Bureau on pers.Fk_IdBureau equals bu.IdBureau
                                   join dep in db.Departament on pers.Fk_IdDep equals dep.IdDep
                                   select new PersonDepBureau
                                   {
                                       IdPerson = pers.IdPerson,
                                       PersonName = pers.Name,
                                       Surname = pers.Surname,
                                       CurrentBureau = bu,
                                       CurrentDepartament = dep
                                   }).ToList();
                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            foreach (var person in persons)
                            {
                                PersonData.Add(person);
                            }
                        }));  
                    
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }     
                }
                IsBusy = false;
            }, CancellationToken.None, TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
