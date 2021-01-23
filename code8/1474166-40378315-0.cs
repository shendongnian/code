    var canvas = WebDriver.FindElement(By.ClassName("canvas-container"));                   
    var size = canvas.Size;
    new Actions(WebDriver)
      .MoveToElement(canvas, 2, 2)
      .ClickAndHold()
      .MoveByOffset(size.Width / 2, size.Height / 2)
      .Release()
      .Perform();
