    foreach(var o in objects)
    {
        o.Update(time);
        
        var e = o is Portal;
        if (e != null)
        {
            e.Interact(ref player, player.Interact);
        }
        else
        {
            ((Enemy)o).Update(time, player);
        }
    }
