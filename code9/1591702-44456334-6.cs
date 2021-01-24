    GameObject[] FindInActiveObjectsByName(string name)
    {
        List<GameObject> validTransforms = new List<GameObject>();
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].gameObject.name == name)
                {
                    validTransforms.Add(objs[i].gameObject);
                }
            }
        }
        return validTransforms.ToArray();
    }
