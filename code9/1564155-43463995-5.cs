    [HttpPost]
    [Route("/email/send")]
    public ActionResult Send(EmailViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            //how do return my model errors back to my View Component?
             return Content(string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)));
           //in send email success javascript method handle this message and show.
             
        }
        else
        {
            //do send logic here
            return Content("Success");
        }
    }
