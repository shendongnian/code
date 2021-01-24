     var objs = GameObject.FindObjectsOfType<Transform>()
     .Where(g =>
     {
         var sr = g.GetComponent<SpriteRenderer>();
         if (sr != null)
         {
             if (sr.sprite != null)
             {
                 if (sr.sprite.name.Equals(_from.name)) { return true; } 
             }
             return false;
         }
         return false;
     }).AsEnumerable();
