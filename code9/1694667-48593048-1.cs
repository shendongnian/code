    using System;
    using Godot;
    
    public class TitleScene : Node
    {
    
      public override void _Ready()
      {
        // Must be cast to the Global type we derived from Node earlier to
        // use its custom methods and props
        Global global = (Global) GetNode("/root/global");
        Godot.GD.Print(global.GetPlayerVars().total);
      }
    
    }
