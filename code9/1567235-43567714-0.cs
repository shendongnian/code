           public class Album
            {
                [Key]
                public int Id { get; set; }
                [Required]
                public string Name { get; set; }
                public string About { get; set; }
                public string Folder { get; set; }
                public bool Approve { get; set; }
                public string Picture { get; set; }
                public System.DateTime CreateDate { get; set; }
                public virtual ICollection<AudioSong> AudioSongs { get; set; }
                public virtual ICollection<Category> Categories { get; set; }
                public virtual ICollection<Tag> Tags { get; set; }
                public bool IsHomePage { get; set; }
                public bool Featured { get; set; }
            }
      public class AudioSong
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            public string Url { get; set; }
            public string Lyrics { get; set; }
            public string Singer1 { get; set; }
            public string Singer2 { get; set; }
            public string Top10 { get; set; }
            public string Top10no { get; set; }
            public string Picture { get; set; }
            public virtual Album Albums { get; set; }
            public System.DateTime CreateDate { get; set; }
            public virtual Lyric_writer Lyric_writers { get; set; }
            public virtual ICollection<Album_comments> Album_comments { get; set; }
            public virtual ICollection<Actor> Actors { get; set; }
            public virtual Category Category { get; set; }
            public bool IsHomePage { get; set; }
            public bool Treading { get; set; }
            public bool IsSlider { get; set; }
        }
