    @model IEnumerable<PersonModel>
    
    @(Html
    .Grid(Model)
    .Build(columns =>
    {
        columns.Add(model => model.Name).Titled("Name");
        columns.Add(model => model.Surname).Titled("Surname");
        columns.Add(model => model.Age).Titled("Age");
        columns.Add(model => model.Birthday).Titled("Birth date");
        columns.Add(model => model.IsWorking).Titled("Employed");
    
    //popup part
    columns.Add(model => $"<a  data-modal='' data-id=\"{model.Id}\"     href='PasswordRestUser/{model.Id}'      id=\"ss\"  asp-    action=\"PR\" asp-route-id=\"@item.Id\" class=\"btn     btn-info\" '> PR <span class='glyphicon      glyphicon-user'> </span> </a>").Encoded(false);
    })
    .Filterable()
    .Sortable()
    .Pageable()
    )
    <div id='myModal' class='modal fade in'>
        <div class="modal-dialog">
            <div class="modal-content">
                <div id='myModalContent'></div>
            </div>
        </div>
    </div>
