     var listadoTabla1 = new List<Table1>
            {
                new Table1{ item_id=1, item_name="apple", qty=5 },
                new Table1{ item_id=2, item_name="orange", qty=10 },
                new Table1{ item_id=3, item_name="tomato", qty=7 }
            };
            var listadoTabla2 = new List<Table1>
            {
                new Table1{ item_id=1, item_name="apple", qty=5 },
                new Table1{ item_id=3, item_name="tomato", qty=1 },
                new Table1{ item_id=4, item_name="squash", qty=5 }
            };
            var listadoResultado = listadoTabla1;
            listadoResultado.AddRange(listadoTabla2);
            var resultado = (from x in listadoResultado
                             group x by new { x.item_id, x.item_name }
                                             into grp
                             select new Table1
                             {
                                 item_id = grp.Key.item_id,
                                 item_name = grp.Key.item_name,
                                 qty = grp.Sum(x=>x.qty)
                             }).ToList();
