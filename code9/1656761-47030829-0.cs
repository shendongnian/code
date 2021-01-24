    [HttpGet]
        [AutorisatieFilter(Rol = "Beheer | Email templates@Lezen")]
        public ActionResult GetOrigineelTemplate(int id = -1)
        {            
    ViewBag.PreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            var model = new EmailTemplateModel();
            model = EmailTemplateService.GetEmailTemplate(Context.Klant.Id, Context.Klant.LogoIDSpecified ? Context.Klant.LogoID : 0, id);
            return Redirect(ViewBag.PreviousUrl);
        }
