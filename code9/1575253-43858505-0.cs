    public GameObject tilePrefab;
          void OnMouseDrag(){
            Vector2 pos = Input.mousePosition;
            pos = Camera.main.ScreenToWorldPoint (pos);
            pos.x = Mathf.Round(pos.x);
            pos.y = Mathf.Round(pos.y);
            transform.position = pos;
            var hitColliders = Physics.OverlapSphere(transform.position, 1);
            if (Input.GetKey (KeyCode.LeftControl)) {
                if (hitColliders.Length == 0) {
                    GameObject myGameObject = Instantiate (tilePrefab) as GameObject;
                    myGameObject.name = "SomePrefabName";
                }
            }
        }
