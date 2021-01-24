        public class DropDownViewModel
        {
           public DropDownViewModel()
           {
              SongList = new List<SelectListItem>();
           }
           public int Id { get; set; }
           
           public string SelectedSongId { get; set; }
           public List<SelectListItem> SongList { get; set; }
        }
