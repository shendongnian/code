    foreach(var o in objects)
    {
        o.Update(time);
    
        if(o is Portal)
        {
            (o as Portal).Interact(ref player, player.Interact);
        }
        else if(o is Enemy)
        {
            (o as Enemy).Update(time, player);
        }
    }
