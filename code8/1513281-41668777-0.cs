        HttpPostedFileBase photo = Request.Files["UploadedPhoto"];
        TeamsService.ServiceClient client = new TeamsService.ServiceClient();
        client.Open();
        if (client.CreateTeam(Session["DynamixSessionId"].ToString(), team.Id, team.Name, team.Coach, ConvertToBytes(photo)))
        {
            client.Close();
            return RedirectToAction("Index", "Teams");
        }
        else
        {
            return View();
        }
