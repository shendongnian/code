        public HttpResponseMessage Post([FromBody]WorkerAbsenceModel absence)
        {
            bool ok = svc.CreateWorkerAbsence(absence);
            if (ok)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
