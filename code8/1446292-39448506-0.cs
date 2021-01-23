    try 
    {
        var response = await client.GetAsync(url);
        ValidateResponse(response.StatusCode);
        var jsonString = await response.Content.ReadAsStringAsync();
        model = JsonConvert.DeserializeObject<GetAddressResults>(jsonString);
    } 
    catch (NotFoundException e) 
    {
        // ...
    }
    catch (ForbiddenException e) 
    {
        // ...
    }
    ...
