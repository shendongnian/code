    @Html.Grid(Model).Columns(columns =>  
                        {  
                            columns.Add(c => c.SchemeID).Titled("Scheme ID").Filterable(true);  
                            columns.Add(c => c.SchemeName).Titled(Model.GridSettings.SchemaColumnTitle).Filterable(true);  
                            columns.Add()  
                            .Encoded(false)  
                            .Sanitized(false)  
                            .SetWidth(30)  
                            .RenderValueAs(o => Html.ActionLink("Edit", "Edit", new { id = o.SchemeID }));  
    
                        }).WithPaging(10).Sortable(true)  
