            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<PartialViewResult> Submit([Bind(Prefix = "Item2")] ContactForm model)
            {
                bool isMessageSent = true;
    
                if (ModelState.IsValid)
                {
                    try
                    {
                        await Services.EmailService.SendContactForm(model);
                    }
                    catch (Exception ex)
                    {
                        isMessageSent = false;
                    }
                    
                }
                else
                {
                    isMessageSent = false;
                    //Return the view that has validation error message display code.
                    return View(model);
                }
                return PartialView("_SubmitMessage", isMessageSent);
            }
