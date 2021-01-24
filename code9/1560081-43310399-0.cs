    @foreach (var item in Model)
    {
        <tr>
            @{
                var type = item.GetType();
                var props = type.GetProperties();
                foreach (var p in props)
                {
                    <td>
                        @p.Name
                    </td>
                    <td>
                        @type.GetProperty(p.Name).GetValue(item);
                    </td>
                }
            }
        </tr>
    }
