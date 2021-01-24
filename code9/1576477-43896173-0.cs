    public class specificController : abstractController
        {
            [HttpPost]
            public override JsonResult mustOverrideMethod([FromBody]YourDataModel yourDataModel)
            {
                //You can now use yourDataModel variable here.
                youDataModel.DoAnythingYouLike etc...
    
            }
         }
