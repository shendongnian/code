    var list = pControls.Controls
                        .OfType<Table>()
                        .Where( c => c.ID == "MyTable")
                        .First()
                        .Controls
                        .OfType<Control>()
                        .Where( c => c is TextBox || c is DropDownList);
