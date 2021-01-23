    foreach(var o in objects)
    {
        o.Update(time);
    
        Portal p = o as Portal;
        
        if(p != null)
        {
            p.Interact(ref player, player.Interact);
        }
        else
        {
            Enemy e = o as Enemy;
            if (e != null)
            {
                e.Update(time, player);
            }
        }
    }
