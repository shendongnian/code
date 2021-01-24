 
    List<string> listHour = new List<string>();
    foreach(var item in oras){
        listHour.Add(item);
    }
    listHour.RemoveRange(1,4);
    oras = listHour.ToArray();
