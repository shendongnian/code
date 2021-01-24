     XmlSerializer ser = new XmlSerializer(typeof(List<Car>));
     int carsPerFile = 100;
     int fileIndex = 1;
     for(int i=0; i<myCars.Count; )
     {
        var cars = myCars.Skip(i).Take(carsPerFile);
        using (var text = XmlWriter.Create(string.Contact("myCars_",fileIndex++,".xml"))
        {
            ser.Serialize(text, cars.ToList());
        }
        i += carsPerFile;
     }
