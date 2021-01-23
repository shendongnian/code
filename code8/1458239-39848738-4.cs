    var mappings = (from gr in entities.ObjectGroup
                    join t in entities.ObjectTypeToObjectGroupMappings
                    on gr.Id equals t.ObjectGroupId into subTs
                    from subT in subTs.DefaultIfEmpty()
                    group new { gr, subT } by new { gr.Id /*and other gr's properties*/} into sub
                    select new ObjectGroupModel 
                    {
                         Id = sub.Key.Id,
                         /*other gr's properties via propN = sub.Key.propN*/
                         ObjectTypeIds = sub.Where(x => x.subT != null).Select(x => x.subT.ObjectTypeId).ToList()
                    }).ToList();
