    var response = await iLab_client.GetAsync(uri);
    var datafile = await response.Content.ReadAsStringAsync();
    var returnDataObj = JsonConvert.DeserializeObject<DTO.RootObject>(datafile);
    
    var names = new List<string>();
    foreach (var form in returnDataObj.cr_response.details)
    {
        names.Add(form.name);    
    }
    return Ok(names); // or return Ok(names.ToArray()); in JSON both will be arrays
