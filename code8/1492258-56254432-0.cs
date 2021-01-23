public async Task<ActionResult> DisplayDashboard()
{
    if (true)
    {
        return RedirectToAction("Index", "Home");
    }
    else
    {
        return View("Error");
    }
}
