        public class AnnotationSharedWithController : ODataController
        {
            [EnableQuery]
            [ODataRouteAttribute("annotation_shared_with")]
            public IQueryable<AnnotationSharedWith> Get()
            {
                //your code
            }
        }
