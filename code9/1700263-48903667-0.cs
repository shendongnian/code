    string point = "";
    try
    {
        string point = "POINT(" + dtTrap.Rows[i][intEastingIndex].ToString() + " " + dtTrap.Rows[i][intNorthingIndex].ToString() + ")";
        dtTrap.Rows[i]["TrapGeog"] = DbGeography.PointFromText(pointWellKnownText: point, coordinateSystemId: SRID);
    }
    catch (Exception ex)
    {
        System.Diagnostics.Debug.WriteLine("correct point? " + point);
        if (ex.InnerException != null)
        {
            MessageBox.Show(ex.InnerException.Message + " at " + point);
        }
        else
        {
            MessageBox.Show(ex.Message);
        }
    }
