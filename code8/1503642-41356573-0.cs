    XElement xmlFileContent = XElement.Load("filePath");
            var datas=  xmlFileContent.Elements("INVENTORYALLOCATIONS.LIST")
                .Select(i =>
                {
                   return new
                    {
                        Rate = i.Element("RATE").Value.Split('/')[0],
                        Actualqty = i.Element("ACTUALQTY").Value.Trim().Split(' ')[0]
                    };
                }).ToList();  
