    bool keyRight = false;
    bool keyUp = false;
    [GLib.ConnectBefore]
    public override void OnKeyDown (object o, global::Gtk.KeyDownEventArgs args)
    { 
        switch (args.Event.Key) 
        {
           case Gdk.Key.Up:
             if(!keyUp)
             {
                keyUp = true;
                playerPhysics.AddVector (_taxiGoUp);
                Player._state = Taxi.State.MoveUp;            
             }
             break;
           case Gdk.Key.Right:
             if(!keyRight)
             {
                keyRight = true;
                playerPhysics.AddVector (_taxiGoRight);
                Player._state = Taxi.State.MoveRight;            
             }
             break;
        }
    }
    [GLib.ConnectBefore]
    public override void OnKeyDown (object o, global::Gtk.KeyUpEventArgs args)
    { 
        switch (args.Event.Key) 
        {
           case Gdk.Key.Up:
             keyUp = false;
             break;
           case Gdk.Key.Right:
             keyRight = false;
             break;
        }
    }
