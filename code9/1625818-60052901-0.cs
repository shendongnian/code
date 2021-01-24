        using System.Text.Json;
.
.
.
        var movies = await JsonSerializer.DeserializeAsync
            <IEnumerable<Movie>>(responseStream,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
