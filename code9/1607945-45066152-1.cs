    this.Where(x => x.Status)
                .GroupBy(item => new { item.FormId, item.Status })
                .Select(x =>
                    new Form
                    {
                        FormId = x.First().FormId,
                        Status = x.First().Status,
                        Version = x.OrderByDescending(c => c.Version).First().Version
                    }
                ).ToList();
