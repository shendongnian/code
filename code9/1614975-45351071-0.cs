     public class MachineController : ApiController
    {
        Machine[] machines = Gateway.test2(10);
     
       
        public IEnumerable<Machine> GetAllMachines()
        {
 
            return machines;
        }
        public IHttpActionResult GetMachine(int id)
        {
            var machine = machines.FirstOrDefault((p) => p.id == id);
            if (machine == null)
            {
                return NotFound();
            }
            else
                return Ok(machine);
        }
        
       
        
    }
}
     public static Machine[] test2(int i)
        {
            Machine[] result = new Machine[i+1];
            for (int j = 0; j < 10; j++)
            {
                
                result[j] = testDatabaseCon(j + 1);
                result[j].id = j + 1;
            }
            result[i] = new Machine();
            result[i].name = "test";
            result[i].description = "test";
            
            result[i].EnteredCount++;
           
            return result;
        }
