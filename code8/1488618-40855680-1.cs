    [Test]
    public async Task AllPartners_HasPartners_GetsThem() {
     var response = new HttpResponseMessage();
     var unescapedjson = Regex.Unescape(JSONString);
     var unescapedjson2 = Microsoft.JScript.GlobalObject.unescape(JSONString);
     response.Content = new StringContent(unescapedjson);
     await _offersDataService.ProcessResponse(response);
     Assert.Greater(_offersDataService.AllPartners.Count, 0);
    }
