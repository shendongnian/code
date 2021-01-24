    [HttpPost]
    public JsonResult InsertSongPlay(SongModel songModel)
    { 
        try
        {
            EntityDataAccess.InsertSongPlay(songModel.songID);
            return Json(true);
        }
        catch(Exception ex)
        {
            return Json(ex);
        }   
    }
    
    public class SongModel{
        public int songID {get;set}
    }
