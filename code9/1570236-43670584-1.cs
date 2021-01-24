        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using System.Net;
        using System.Net.Http;
        using System.Threading;
        using System.Threading.Tasks;
        using System.Web;
        using System.Web.Http;
        namespace WebApplication1.Controllers
        {
            public class StripeController : ApiController
            {
                [HttpPost]
                [Route("api/stripewebhook")]
                public IHttpActionResult Index()
                {
                    var json = new StreamReader(HttpContext.Current.Request.InputStream).ReadToEnd();
                    var stripeEvent = StripeEventUtility.ParseEvent(json);
                    switch (stripeEvent.Type)
                    {
                        case StripeEvents.ChargeRefunded:  // all of the types available are listed in StripeEvents
                            var stripeCharge = Stripe.Mapper<StripeCharge>.MapFromJson(stripeEvent.Data.Object.ToString());
                            break;
                    }
                    return Ok();
                }
            }
        }
