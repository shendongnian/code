    public void OnHideClick()
    {
      AllText.Remove(this.gameObject);
      if (newSwitchOne)
      {
          switchOn = true;
      }
      else if (newSwitchTwo)
      {
          switchOff = true;
      }
    }
