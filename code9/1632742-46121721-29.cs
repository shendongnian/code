    using static WebApplication1.Models.QueryTreeHelper;
    public class FilterController
    {
        [HttpGet]
        [ReadRoute("")]
        public Entity[]  GetList(QueryTreeNode queryRoot, string entityType)
        {
            var type = Assembly.GetExecutingAssembly().GetType(entityType);
            var entities = someRepository.GetType()
                .GetMethod("GetEntities")
                .MakeGenericMethod(type)
                .Invoke(dbContext, queryRoot);
        }
        // A sample tree to test the view
        [HttpGet]
        public ActionResult Sample()
        {
            return View(
                Branch(
                    Branch(
                        Leaf("a", 1),
                        Branch(
                            Leaf("d", 4),
                            Leaf("b", 2))),
                    Leaf("c", 3)));
        }
    }
