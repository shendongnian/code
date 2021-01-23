    public Task<ActionResult> DisplayDashboard()
    {
            ActionResult result;
            if (true)
            {
                result = RedirectToAction("Index", "Home");
            }
            else
            {
                result = View("Index");
            }
            return Task.FromResult(result);
        }
