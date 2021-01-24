     public IEnumerable<TableVm> GetTableByGroupWithPag(int groupId, ApplicationDbContext context,int pageNumber, int rowsPerPage)
            {
            
                var table = context.Tables.Skip((pageNumber-1)*rowsPerPage).Take(rowsPerPage).ToList();
    
                var visibility = context.TableVisibilitySettings.FirstOrDefault(x => x.GroupId == groupId);
    
                return table.Select(x => new TableVm
                {
                    Id = x.Id,
                    Group = x.Grup.Name,
                    Color = x.Color,
                    ConstructionYear = visibility.ContructionYear == true ? x.ConstructionYear : null,
                    Power = visibility.Power == true ? x.Power : null,
                    IsConvertible = visibility.IsConvertible == true ? x.IsConvertible : null
                }).ToList();
            }
