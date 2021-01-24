        [HttpGet]
        public JsonResult client_token()
        {
            var gateway = config.GetGateway();
            var clientToken = gateway.ClientToken.Generate();
            return Json(clientToken, JsonRequestBehavior.AllowGet);
        }
