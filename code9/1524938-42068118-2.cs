    public interface IBoardService {
        Board GetById(int id);
        //...other code removed for brevity
    }
    public class BoardController : ApiController {
        readonly IBoardService dataSource;
        public BoardController(IBoardService dataSource) {
            this.dataSource = dataSource;
        }
    
        // /api/board/getbyid?id=123
        public IHttpActionResult GetById(int id) {
            var board = dataSource.GetById(id);
            if (board == null)
                return NotFound();
    
            return OK(board);
        }
    }
