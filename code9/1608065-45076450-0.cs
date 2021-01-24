    private bool HasBeenProgrammaticallyToggled = false;
    
    public void ThisIsAProgrammaticToggle()
    {
          HasBeenProgrammaticallyToggled = true;
          farmSwitch.toggled = true;
    }
