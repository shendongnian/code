    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WeeklyReport.Models;
    namespace WeeklyReport.Repository
    {
        public interface IDataRepository
        { 
            IEnumerable<ReportViewModel> GetAllMetrics();
        }
    }
