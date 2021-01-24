    namespace client.Models
    {
        public class JoinUsersandJobsModel : DbContext
        {
        public tradesusers tradesusers { get; set; }
        public jobs jobs { get; set; }
        public uploadedfiles uploadedfiles { get; set; }
        //Blob service does not need to be here
    }
