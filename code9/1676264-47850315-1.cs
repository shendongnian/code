      public static void UseAndClose(Action<Excel> pAction) {
         using (var excel = new Excel()) {
            pAction(excel);
            excel.Close(false); // closes all workbooks and then calls `Quit`
         }
      }
