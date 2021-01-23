        public ActionResult Index(string playerId)
        {
            var model = new MultiPlayerLabelModel();
            try
            {
                var player = ServiceFactory.GetPlayerService().GetPlayer(playerId);
                model = ServiceFactory.GetLabelService().GetLabelModels(player.Position, null);
            }
            catch (Exception)
            {
                LogService.Log.Error("Failed to generate label for player");
            }
            return View("Multi", model);
        }
