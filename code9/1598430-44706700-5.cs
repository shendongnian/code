         public ActionResult Blog()
        {
            //Create a MessageViewModel and assign its properties...
            var viewModel = new MessageViewModel()
            {
               Messages = _context.messages.OrderByDescending(m => m.WhenCreated),
               Comments =  _context.comments
            };
            // Pass the MessageViewModel to your view.
            return View(viewModel);
        }
