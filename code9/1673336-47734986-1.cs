     [HttpPost]
     [ValidateAntiForgeryToken]
     public async Task<IActionResult> SaveAndSend(ModelView model)
     {
          //This is never used, but is needed in "static async Task Execute()"
          ApplicationDBContext db = new ApplicationDBContext();
          // Await the Execute method call, instead of Wait()
          await Execute();
        .....
    }
