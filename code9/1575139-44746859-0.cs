    int curAngle = (int)el.Rotation;
    if (curAngle < 10 && angle > 350)
    {
       await el.RotateTo(0, 125);
       el.Rotation = 359.9;
       await el.RotateTo(angle, 125);
    }
    else if (curAngle > 350 && angle < 10)
    {
      await el.RotateTo(360, 125);
      el.Rotation = 0.1;
      await el.RotateTo(angle, 125);
    }
    else
    {
      await el.RotateTo(angle, 250);  
    }
