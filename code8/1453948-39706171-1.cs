    var gridColumns = new List<WebGridColumn>();
    @if(ColumnNameBool)
    {          
          gridColumns.Add(grid.Column("ProjectName", 
                           @Resources.Localization.project, format: @<text>
                                    @if (Model.ColumnsNeeded.ProjectNameBool)
                                    {
                                        <span class="display-mode">
                                        <label id="ProjectNameLabel">
                                        @item.ProjectName</label>
                                        </span>
                                    }
                                </text>,style : "hidden-column"));
                   )
                 //... add other required columns here
    }
    else
    {
          //create here another list of columns that required
          gridColumns.Add(...);   
                   
    }
