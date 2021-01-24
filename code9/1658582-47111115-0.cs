    for (int i = 0; i < listTest1.Count; i++) {
        bool abbrvFound = false;
        for (int a = 0; a < listTest2.Count; a++) {
            if (listTest1[i].abbrv != listTest2[a].abbrv)
                continue;
            abbrvFound = true;
            if (listTest1[i].date == listTest2[a].date) {
                listTest3.Add(listTest2[a]);
            } else {
                listTest3.Add(new Test.Test2() { abbrv = listTest2[a].abbrv, date = listTest2[a].date, completed = true, abbrevName = listTest2[a].abbrevName });
                listTest3.Add(new Test.Test2() { abbrv = listTest1[i].abbrv, date = listTest1[i].date, completed = listTest1[i].completed, abbrevName = string.Empty });
            }
        }
        if (!abbrvFound) {
            listTest3.Add(new Test.Test2() { abbrv = listTest1[i].abbrv, date = listTest1[i].date, completed = listTest1[i].completed, abbrevName = string.Empty });
        }
    }
