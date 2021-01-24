    foreach (TableCell row in e.Row.Cells)
    {
        if (design1.Any(x => x == e.Row.Cells[0].Text.ToUpper())) { row.CssClass += " des1"; }
        else if (design2.Any(x => x == e.Row.Cells[0].Text)) { row.CssClass += " des2"; }
        else if (design3.Any(x => x == e.Row.Cells[0].Text)) { row.CssClass += " des3"; }
        else { row.CssClass += " defaultview"; };
    }
