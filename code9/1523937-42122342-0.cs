       [System.Web.Http.RoutePrefix("spapi/MIC_REST")]
    public class SPController :ApiController
    {
        private MICdB db = new MICdB();
  
        [System.Web.Http.Route("part/{jobID:int}/{fmNumber:int}/{workAreas}")]
       // [EnableQuery]
         public List<up_BomAssemParts_s_ByJobID_FmNumber_WorkArea_Result> GetPartsLists([FromODataUri]int jobID, [FromODataUri]int fmNumber, [FromODataUri]string workAreas)
        {
            return db.up_BomAssemParts_s_ByJobID_FmNumber_WorkArea_TEST(jobID, fmNumber, workAreas).ToList();
        }
    }
