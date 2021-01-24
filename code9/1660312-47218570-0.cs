    bool pressedSpace = false;
        void Update() {
            pressedSpace = true; // Only called once
            if (!pressedSpace && Input.GetKeyDown("space") /*( || Input.GetMouseButtonDown(1))*/) {
        
                if (map.selectedUnit.GetComponent<Unit>().carrying) {
                    print("DROP space");
                    map.selectedUnit.GetComponent<Unit>().carrying = false;
                }
                // pick up monster while on top of it
                else {
                    for(int i = 0; i < map.monsterList.Count; i++) {
                        if (map.monsterList[i].GetComponent<Monsters>().tileX == map.selectedUnit.GetComponent<Unit>().tileX &&
                            map.monsterList[i].GetComponent<Monsters>().tileY == map.selectedUnit.GetComponent<Unit>().tileY &&
                            map.occupationArray [map.monsterList[i].GetComponent<Monsters>().tileX, map.monsterList[i].GetComponent<Monsters>().tileY] == true) {
                                print("PICKUP space");
                                map.selectedUnit.GetComponent<Unit>().carrying = true;
                            }
                    }
                }
            }
        }
