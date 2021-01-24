    public bool DeleteSong()
        {
            int _deleteResult=0;
            string _songId = Request.QueryString["id"];
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
            Song songsMaster = _context.Songs.Single(m => m.SongId == _songId);
                _context.Songs.Remove(songsMaster);
               _deleteResult= _context.SaveChanges();
            }
           if(_deleteResult>0)
           {
             return true;
           }
           else
           {
            return false;
           }
        }
