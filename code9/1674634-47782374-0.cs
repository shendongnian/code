    public ActionResult DefCon5(string DefCon5,string message)
            {
                //string yes = Request.Params["Yes"];
                //string no = Request.Params["No"];
                //var DefCon5 = Request["DefCon5"];
                //string message = Request.Params["message"];
                string redirURL = "";
    
    
                if (DefCon5.ToLower() == "yes")
                {
                    Response.Write(@message);
                    //Response.Write(@Defcon);
                    redirURL = "/somepage";
                }
                else
                {
    
                    redirURL = "/DefCon5";
                } 
                // your code here
                return View();
            }
