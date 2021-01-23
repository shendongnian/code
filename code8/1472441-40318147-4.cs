    var result = parents.Join(children,
                         p => p.ParentId,
                         c => c.ParentId,
                         (p,c) => new { parents = p,children = c  })
                         .Select(x => new
                         {
                             ParentName = x.parents.ParentName,  
                             ChildList= x.children
                         })
                         //.GroupBy(x=>x.ParentName )
                         .ToList();
