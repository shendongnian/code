       if (Input.GetMouseButtonDown(0))
       {
          var go = UnityEngine.Object.Instantiate(BuildingPrefab);
       }
        go.transform.position = transform.position;
        go.AddComponent<Player>().Info = Info;
        Destroy(this.gameObject);
