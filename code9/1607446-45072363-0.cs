    var company = _companyRepository.GetAll()
                                    .Include(c => c.Addresses)
                                    .Include(c => c.Contacts)
                                    .Include(c => c.Note)
                                    .FirstOrDefault(x => x.Id == input.Id);
