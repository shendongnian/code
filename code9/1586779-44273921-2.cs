    var controls = pControls.Controls
                            .OfType<Table>()
                            .Where( c => c.ID == "MyTable")
                            .First()
                            .Controls;
