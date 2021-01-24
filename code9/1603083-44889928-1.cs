    if (ModelState.IsValid)
    {
      // your other code goes here
      if (!response.IsSuccessStatusCode)
      {
         // to do : Log errors for you :)
         ModelState.AddModelError(string.Empty,"Some error message");       
      }
    }
    return View(viewModel);
