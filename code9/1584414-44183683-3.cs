    @model XXX.Group
    
    @foreach (var item in Model)
    {
         <div data-role="collapsible">
             <h4> @item.GroupName </h4>
             <ul data-role="listview">
                @foreach (var item2 in Model.SubName)
                {
                    <li><a href="#">item2.SubGroupName </a></li>
                }
             </ul>
         </div>
    }
