    [HttpPost]
    public ActionResult ToHex(ClsTextToHex model)
    {
        if (!model.IsHex)
        {
            model.Text = "Hex" + model.Text;  // My temp hexification code :). Fix this
            model.IsHex = true;
        }
        else
        {
            //My temp un-hexification code :) Fix this with your actual code
            model.Text = model.Text.Replace("Hex", ""); 
            model.IsHex = false;
        }
        ModelState.Clear();  // This will clear the model state dictionary
        return View(model);
    }
