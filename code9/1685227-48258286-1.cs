    @model Dictionary<string, List<object>>
    
    @foreach (var table in Model)
    {
        var properties = table.Value.First().GetType().GetProperties();
        <h4>@table.Key</h4>
        <table>
            <thead>
                <tr>
                    @foreach (var head in properties)
                    {
                        <th>@head.Name</th>
                    }
                </tr>
            </thead>
            <tbody>
                @foreach (var item in table.Value)
                {
                    @:<tr>
                        foreach (var property in properties)
                        {
                           <td>@property.GetValue(item)</td>
                        }
                    @:</tr>
                }
            </tbody>
        </table>
    }
