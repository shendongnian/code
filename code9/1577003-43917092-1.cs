    @(Html.DevExtreme().DataGrid()
        //...
        .Columns(c => {
            c.Add().DataField("CompanyName").CellTemplate(@<text>
                @(Html.DevExtreme()
                    .Button()
                    .Text("Click me")
                    .OnClick("onButtonClick.bind(this, arguments[0])"))
            </text>);
            //...
        })
    )
    
    <script>
        function onButtonClick(cellInfo, evt) {
            //use the cellInfo argument here
        }
    </script>
