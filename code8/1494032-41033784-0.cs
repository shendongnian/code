     var result =
         from item in items
         group item by item.FieldA into grp
         let nonEmpty =
             from g in grp
             where !String.IsNullOrEmpty(g.FieldB)
             select g
         from subItem in nonEmpty.Any() ? nonEmpty : grp
         group subItem by new { subItem. FieldA, subItem.FieldB } into subGrp
         select subGrp.First();
