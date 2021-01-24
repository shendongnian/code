    using (var stream = await response.Content.ReadAsStreamAsync())
    {
        var dcjs = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(tubeStatusRootObject[]));
        var data= (tubeStatusRootObject[])dcjs.ReadObject(stream);
    }
