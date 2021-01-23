    partial class ResourcesController {
        [HttpGet, Route]
        public ... ListAllResources() {
            // ...
        }
    
        [HttpGet, Route("{publicKey:guid}"]
        public ... ShowSingleResource(Guid publicKey) {
            // ...
        }
    }
