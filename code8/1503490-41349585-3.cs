    [HttpPost]
    public IActionResult LoadPage(Message message)
    {     
        message.Text = "Pageloads: ";
        message.Number += 1;
        ModelState.Clear();
        return View("LoadPage", message);
    }
