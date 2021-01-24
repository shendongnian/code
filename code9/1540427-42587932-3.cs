    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
    
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                bone = hit.collider.transform;
    
    
                if (boneList.Contains(bone))
                {
                    //Object Clicked is already in List. Remove it from the List then UnHighlight it
                    boneList.Remove(bone);
                    UnHighlight(boneList);
                }
                else
                {
                    //Object Clicked is not in List. Add it to the List then Highlight it
                    boneList.Add(bone);
                    Highlight(boneList);
                }
            }
        }
    }
