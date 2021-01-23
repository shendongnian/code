    foreach(var o in objects)
    {
        o.Update(time);
    
        if (o is Portal)
        {
            ((Portal)o).Interact(ref player, player.Interact);
        }
        else if(o is Enemy)
        {
            ((Enemy)o).Update(time, player);
        }
    }
