    var mappings = from gr in entities.ObjectGroup
                   join t in entities.ObjectTypeToObjectGroupMappings
                   on gr.Id equals t.ObjectGroupId into subTs
                   from subT in subTs.DefaultIfEmpty()
                   group new { gr, subT } by new {gr.Id, gr.Test /*and other gr's properties*/} into sub
                   select new ObjectGroupModel 
                   {
                        Id = sub.Key.Id,
                        Test = sub.Key.Test,
                        /*other gr's properties via sub.Key.propN*/
                        ObjectTypeIds = sub.Select(x => x.subT)
                   };
