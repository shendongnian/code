    foreach(var o in objects)
    {
        o.Update(time);
    
        if ((o as Portal) != null)
        {
            ((Portal)o).Interact(ref player, player.Interact);
        }
        else if((o as Enemy) != null)
        {
            ((Enemy)o).Update(time, player);
        }
    }
