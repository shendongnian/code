    public void OnButton()
        {
            for (int i = 0; i < instantiateobjects.Length; i++)
            {
                if (toggleOnOf == false)
                {
                    instantiateobjects[i].generateObjectOnTerrain();
                }
                else
                {
                    instantiateobjects[i].DestroyObjects();
                    instantiateobjects[i].generateObjectOnTerrain();
                    destroyed = true;
                }
            }
        }
