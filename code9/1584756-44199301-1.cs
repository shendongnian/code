    using System.Collections.Generic;
    using System.Web.Http;
    using AppName.Models;
    using AppName.Service;
    using System.Linq;
    using AppName.ViewModels;
    using System.Net.Http;
    using System.Net;
    using System.Web.Http.Cors;
    
    namespace Api.Services
    {
        // Allow CORS for all origins. (Caution!)
       //[EnableCors(origins: "*", headers: "*", methods: "*")]
        public class ApiProductoTipoController : ApiController
        {
    		public class myobj{
                public int delegacion { get; set; }
                public int municipio { get; set; }
                public int ejercicio { get; set; }
                public int recinto { get; set; }
                public string tipo { get; set; }
    
            }
    		
            private readonly IProductoTipoService productoTipoService;
    
            public HttpResponseMessage Options()
            {
                return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
            }
    
            public ApiProductoTipoController(IProductoTipoService productoTipoService)
            {
                this.productoTipoService = productoTipoService;
            }
    
            [HttpPost]
            [Route("~/ApiProductoTipo/CalculaPTRecinto")]
             public HttpResponseMessage CalculaPTRecinto(myobj data)
            {        
    			var tipo = data.tipo;
                ...
            }
        }}
