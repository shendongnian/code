    if (collider.tag != "Player" && collider.tag == "Zombie"){
        ObjectsInRange.Add(collider.gameObject);
        damage = ObjectsInRange.Count; //amount of zombies inside collider
        if(collider.GetComponent<Zombie>().Damage(damage)){
            // if zombie dead, remove him.
            ObjectsInRange.Remove(collider.gameObject);
        }
        Debug.Log(damage);
    }
