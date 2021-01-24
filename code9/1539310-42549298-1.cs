    public static void ShortcutDetect() {
      // Take loop independent code out of the loop:
      // and, please, format it out:
      var source = Program.key
        .Replace("LShiftKey", "Shift")
        .Replace("RShiftKey", "Shift")
        .Replace("RMenu", "Alt")
        .Replace("LMenu", "Alt")
        .Replace("RControlKey", "Ctrl")
        .Replace("LControlKey", "Ctrl");
    
      // Wrong type of loop (while): what is ShortkeyIndex?
      // where has it been declared, why 1000?
      // Please, have a look how the right loop easy to implement and read   
      foreach (var item in RawShortkeys) {
        // Debug: let's output item onto Console
        // Console.WriteLine(item);
        // Debug: ...or in the file
        // File.AppendAllText()@"C:\Users\OEM\Desktop\log.txt", " " + item); 
    
        if (source.EndsWith(item)) // <- put a break point here, inspect item's
          MessageBox.Show(item);
      }
    }
