    xdoc.Descendants("Father").Select(p => new
    {
        Son1 = p.Element("Son1").Value,
        Son2 = p.Element("Son2").Value,
        Son3= p.Element("Son3").Value,
        Son4 = p.Element("Son4").Value,
        Sons5 = p.Elements("Son5").Select(element => element.Value).ToList()
    }).ToList().ForEach(p =>
    {
        Response.Write("Son1= " + p.Son1 + "  ");
        Response.Write("Son2=" + p.Son2 + "  ");
        Response.Write("Son3=" + p.Son3 + "  ");
        Response.Write("Son4 =" + p.Son4 + "  ");
        p.Sons5.ForEach(son5 => Response.Write("Son5 =" + son5 + "  "));
        Response.Write("<br />");
    });
