    class Window2 :Window
    {
    ...
       private void func()
       {
          ConnectionManager.init("COM1");
          ConnectionManager.MessageReceived += this.MessageReceived;
          ConnectionManager.Send("test123");
       }
    }
