    using System;
    using Godot;
    
    public class Global : Node
    {
    
      private PlayerVars playerVars;
    
      public override void _Ready()
      {
        // Called every time the node is added to the scene.
        // Initialization here
        Summator summator = new Summator();
        playerVars = new PlayerVars();
    
        playerVars.total = 5;
      
        Godot.GD.Print(what: "total is " + playerVars.total);
      
      }
    
      public PlayerVars GetPlayerVars(){
        return playerVars;
      }
    
    }
