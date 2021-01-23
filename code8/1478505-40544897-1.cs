        [ODataRoutePrefixAttribute("annotation_shared_with")]
        public class AnnotationSharedWithController : ODataController
        {
            [EnableQuery]
            [ODataRouteAttribute("")]
            public IQueryable<AnnotationSharedWith> Get()
            {
                //your code
            }
        }
