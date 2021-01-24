            if (ModelState.IsValid)
            {
                try
                {
                    if (data != null && data.Company != null)
                    {
                        if (_context.Employee.Company.Any(x => x.Code == data.Company.Code))
                        {
                            data.Company = null;
                            _context.Employee.Add(data);
                        }
                        else
                        {
                            _context.Employee.Add(data);
                        }
                    }
                    return Ok(_context.SaveChanges());
                }
                catch (Exception ex)
                {
                }
            }
            return BadRequest(ModelState);
