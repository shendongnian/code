     public class Song //Class name - could be anything, so long as it suits you
     {
        public bool Favourite { get; set; } //Value for CheckBox #1 - whether it is a favourite
                                            //(true - checked) or not (false - unchecked)
        public bool Play { get; set; } //Value for CheckBox #2 - whether the song is played
                                       //when its turn is reached (true - play/false - skip)
        public string Name { get; set; } //A string value of the name of the song
     }
