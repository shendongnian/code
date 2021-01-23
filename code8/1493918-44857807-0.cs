    public CopyableCommand : Command 
    {
       public CopyableCommand DeepCopy(ICopyCommandMutation commandMutation = null)
       {
          var newCommand = (CopyableCommand)MemberwiseClone();
          if (commandMutation == null) commandMutation = new NoMutation();
          commandMutation.Mutate(newCommand);
          return newCommand;
       }
    }
