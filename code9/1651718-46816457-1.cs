    var results = from e in searchBase
              where
                    e.FirstName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    e.LastName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    e.RMMarket.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    !e.IsSummaryNull() && e.Summary.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0
              select new SearchResult {
                  EmployeeId = e.EmployeeId,
                  Name = e.FirstName + " " + e.LastName,
                  Title = e.Title,
                  ImageUrl = e.IsImageUrlNull() ? string.Empty : e.ImageUrl,
                  Market = e.RMMarket,
                  Group = e.Group,
                  Summary = e.IsSummaryNull() ? string.Empty : e.Summary.Substring(1, e.Summary.Length < summaryLength ? e.Summary.Length - 1 : summaryLength),
                  AdUserName = e.AdUserName
              };
