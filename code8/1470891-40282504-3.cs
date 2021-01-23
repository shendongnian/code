    var idsNotInB = dt
                      .AsEnumerable()
                      .Select(_ => _.Field<object>("OrderId").ToString())
                      .Except(dt1.AsEnumerable().Select(_ => _.Field<object>("OrderId").ToString()));
    DataTable TableC = dt
                         .AsEnumerable()
                         .Where(_ => idsNotInB.Contains(_.Field<object>("OrderId").ToString()))
                         .CopyToDataTable();
