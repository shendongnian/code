    var _factory = Globals.Factory;
    var wsEvars = _factory.GetVstoObject((Excel.Worksheet)wb.Sheets["wsEvars"]);
    var wsProps = _factory.GetVstoObject((Excel.Worksheet)_wb.Sheets["wsProps"]);
    var wsEvents= _factory.GetVstoObject((Excel.Worksheet)_wb.Sheets["wsEvents"]);
    var wsListVars = _factory.GetVstoObject((Excel.Worksheet)_wb.Sheets["wsListVars"]);
    var sheets = new [] { wsEvars, wsProps, wsEvents, wsListVars };
