    [RoutePrefix("api/Catalogos")]
    public class CatalogosController : ApiController {
    
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.HttpGet]
        [Route("")] //Matches GET api/Catalogos
        public HttpResponseMessage Get() {
             HttpRequestMessage request = this.Request;
             //some code there
        }
    
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.HttpGet]
        [Route("GetCatalogo")] //Matches GET api/Catalogos/GetCatalogo
        public HttpResponseMessage GetCatalogoPadre(string catalogo) {
              HttpRequestMessage request = this.Request;
              //some code there
        }
    
    }
