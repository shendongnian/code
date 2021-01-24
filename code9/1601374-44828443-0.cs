    var json = "[2, \"2\", \"text\"]";
    var array = JsonConvert.DeserializeObject<JArray>(json);
    foreach (var item in array)
    {
        switch (item.Type)
        {
            // Continue parsing/processing accordingly   
        }
    }
