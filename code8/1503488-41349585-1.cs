    [HttpPost]
    public IActionResult LoadPage(Message message)
    {
        Message message1 = new Message();
        message1.Text = "Pageloads: ";
        message1.Number += 1;
        ModelState.Clear();
        return View("LoadPage", message);
    }
