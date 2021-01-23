    List<YourObject> pList = spanList.Where(p => p.ClassName == "p").ToList();
    List<YourObject> sList = spanList.Where(p => p.ClassName == "s").ToList();
    if (pList.Count == 2 && sList.Count == 2)
    {
        lesson.lesson2Name = pList[1].TextContent;
        lesson.lesson2Place = sList[1].TextContent;
        lesson.lesson2Tag = adressList.Where(p => p.ClassName == "n").ToList()[1].TextContent;
        lesson.lesson2TagHref = adressList[1].GetAttribute("href");
    }
    else if (pList.Count == 4 && sList.Count == 2))
    {
        lesson.lesson2Name = pList[2].TextContent;
        lesson.lesson2Place = sList[1].TextContent;
        lesson.lesson2Tag = pList.ToList()[3].TextContent;
        lesson.lesson2TagHref = "";
    }
