    public class TanamanhasSensorController : ApiController {
        private SmartGreenHouseEntities db = new SmartGreenHouseEntities();
    
        // GET: api/TanamanhasSensor
        [HttpGet]
        public IQueryable<Tanaman_has_Sensor> GetTanaman_has_Sensor() {
            return db.Tanaman_has_Sensor;
        }
    
        // GET: api/TanamanhasSensor/5
        [HttpGet]
        [ResponseType(typeof(Tanaman_has_Sensor))]
        public async Task<IHttpActionResult> GetTanaman_has_Sensor(int id) {
            Tanaman_has_Sensor tanaman_has_Sensor = await db.Tanaman_has_Sensor.FindAsync(id);
            if (tanaman_has_Sensor == null) {
                return NotFound();
            }
    
            return Ok(tanaman_has_Sensor);
        }
    }
