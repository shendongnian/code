     public ActionResult Blog()
        {
            var messages = _context.messages.ToList();
            // Your view is expecting a parameter of type MessageViewModel,
            // but you're passing it an object of type List<Messages>
            return View(_context.messages.OrderByDescending(Messages => 
            Messages.WhenCreated));
        }
