    var list = pControls.Controls
                        .OfType<Table>()
                        .Where( c => c.ID == "MyTable")
                        .First()
                        .Controls
                        .Where( c => c is TextBox || c is DropDownList);
