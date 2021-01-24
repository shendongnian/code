      private int precision = 2;
      private int movement = 0;
      protected override void OnValueChanged(double oldValue, double newValue) 
      {
        bool keyShift = (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)) 
    
        if (keyShift && movement % precision == 0)
        {
          base.OnValueChanged(oldValue, newValue); 
        }
        else if (!keyShift)
        {
          base.OnValueChanged(oldValue, newValue); 
        }
     
        movement++;
        if (movement == int.MaxValue) movement = 0;
     }
    }
