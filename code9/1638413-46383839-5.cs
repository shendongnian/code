    public class Table
        {
            public int Id { get; set; }
            public int GroupId { get; set; }
            public virtual Group Grup { get; set; }
    
            public string Color { get; set; }
            public int? ConstructionYear { get; set; }
            public string Power { get; set; }
            public bool? IsConvertible { get; set; }
    
    
            public IEnumerable<TableVm> GetTableByGroupType(int groupId, ApplicationDbContext context)
            {
                var table = context.Tables.ToList();
                var visibility = context.TableVisibilitySettings.FirstOrDefault(x => x.GroupId == groupId);
    
                return table.Select(x => new TableVm
                {
                    Id = x.Id,
                    Brand= x.Grup.Name,
                    Color = x.Color,
                    ConstructionYear = visibility.ContructionYear == true ? x.ConstructionYear : null,
                    Power = visibility.Power == true ? x.Power : null,
                    IsConvertible = visibility.IsConvertible == true ? x.IsConvertible : null
                }).ToList();
            }
        }
