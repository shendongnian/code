    @{
        JArray jsonAsArray = JsonConvert.DeserializeObject(Model.JsonData) as JArray;
    
        var classes = jsonAsArray
            .OfType<JObject>()
            .ToList();
        var nonClasses = jsonAsArray
            .Where(x => x.Type != JTokenType.Object)
            .ToList();
    }
    
    <table class="table" style="background-color: white;">
        <thead>
            <tr>
                @{
                    var anyClass = classes.FirstOrDefault();
                    if (anyClass != null)
                    {
                        var properties = anyClass.Properties().Select(x => x.Name).ToList();
                        foreach (var property in properties)
                        {
                            <th>@property</th>
                        }
                    }
                    else
                    {
                        <th>Data</th>
                    }
                }
            </tr>
        </thead>
        <tbody>
            @foreach (JObject item in classes)
            {
                <tr>
                    @foreach (var property in item.Properties())
                    {
                        if (property.Value.Type == JTokenType.Array)
                        {
                            var model = new MyModel();
                            model.JsonData = property.Value.ToString();
                            <td>
                                @Html.Partial("Details_SingleLevelResult", model)
                            </td>
                        }
                        else if (property.Value.Type == JTokenType.Object)
                        {
                            var inlineClass = ((JObject)property.Value).Properties();
                            var resultado = inlineClass.Select(x => string.Format("<div><b>{0}</b> <span>: {1}</span></div>", x.Name, x.Value)).ToList();
                            string resultadoUnido = string.Join("", resultado);
                            <td>
                                <div>
                                    @Html.Raw(resultadoUnido)
                                </div>
                            </td>
                        }
                        else
                        {
                            <td>@property.Value</td>
                        }
                    }
                </tr>
            }
            @foreach (JValue item in nonClasses)
            {
                <tr>
                    <td>@item.Value</td>
                </tr>
            }
        </tbody>
    </table>
