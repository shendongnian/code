    var listOfPossibleCars = new List<string>();
    var dt = new DataTable();
    dt.Columns.Add("CarName");
    foreach (var car in listOfPossibleCars) {
         dt.Rows.Add(car);
    }
    var possibleCars = new SqlParameter("possibleCars", SqlDbType.Structured);
    possibleCars.Value = dt;
    possibleCars.TypeName = "dbo.MyType";
    var listOfCars = db.Cars.SqlQuery("select C.* from Cars C inner join @possibleCars P on C.CarName = P.CarName", possibleCars).ToList();
