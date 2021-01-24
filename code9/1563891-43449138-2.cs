    using System;
    using System.Web.Mvc;
    public class BusinessLogicController : Controller {
        private readonly IStationController stationController;
    
        public BusinessLogicController(IStationController stationController) {
            this.stationController = stationController;
        }
    
        // Use the IStationController object in various calls
    }
