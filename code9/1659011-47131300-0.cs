     var result = persons.GroupBy(c => c.Email).Select(c => new Person()
                {
                    Email = c.First().Email,
                    Name = string.Join(", ", c.Select(b=>b.Name).ToList())
                });
