                [AcceptVerbs(HttpVerbs.Post)]
                [Authorize]
                [ValidateAntiForgeryToken()]
                public ActionResult emailupdate(UserEmailEditModel editmodel_post)
                {   
                    if (!ModelState.IsValid)
                    {   
                      // redirect to email view and show errors
                    }
                    
                    // check if posted id is the same as stored in session
                    if (User.Identity.GetUserId() != editmodel_post.user_id.ToString())
                    {
                       // redirect to email view and show errors
                    }
                }
