    using System.Web.Script.Serialization;
    ....
        var values = new Dictionary<string, string>();
        values.Add("truckdetails",  new JavaScriptSerializer().Serialize(truckdetails));
        values.Add("check_comments", new JavaScriptSerializer().Serialize(check_comments));
        values.Add("general_comment", general_comment);
        var body = new FormUrlEncodedContent(values);
        var response = await http.PostAsync(url, body);
        return response;
