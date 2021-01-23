        var r = SendPost(apiPath, command);
        if (r.Code == OK && r.Response != null)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new JsonResponseConverter());
            var jsonResponse = JsonResponse<T>.Deserialize(r.Response, settings);
            ...
        }
