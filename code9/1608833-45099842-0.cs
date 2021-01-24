    SqlParameter p = new SqlParameter();
    p.Name = "@GeoLoc";
    p.Value = SqlGeography.Parse(geoLocation.AsText());
    p.SqlDbType = SqlDbType.Udt;
    p.UdtTypeName = "geography";
    updationCommand.Parameters.Add(p);
