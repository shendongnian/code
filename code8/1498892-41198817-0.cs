    var sedi = new List<string>();
    sedi.Add("Via Gavinana, 19, Roma");
    sedi.Add("Val de Seine, 94600 Choisy le Roi");
    sedi.Add("Street 21,Shuwaikh, Kuwait");
    ViewBag.sediList = Json.Encode(sedi);
    // No need to pass the viewbag in View param
    return View();
