    //Define as global variable a list of Monsters
    List<GameObject> monsterList = new List<GameObject>();
    
    //Then you instantiate then like
    monsterList .add((GameObject)Instantiate(selectedMonster.GetComponent<Monsters>().Monster, new Vector3(Random.Range(1,8), Random.Range(1,8), -1), Quaternion.identity));
