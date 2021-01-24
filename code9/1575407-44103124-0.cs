    @foreach (var thing in Model.CollectionOfThings)
    {
        <tr>
            @foreach (var prop in typeof(Thing).GetProperties())
            {
                <td>
                    @{
                        Html.RenderPartial("~/Views/Shared/_DisplayForReflectedProperty.cshtml", 
                        new Tuple<Thing, PropertyInfo>(thing, prop));
                    }
                </td>
            }
    }
