              var responseData = responseMessage.Content.ReadAsStringAsync().Result;
              if (responseData=="true")
              {                    
                  return View("Show", login); // Return the "Show.cshtml" view if user is valid
              }
              else
              {
                  ViewBag.Message = "Invalid Username or Password";
                  return View(); //return the same view with message "Invalid Username or Password"
              }
