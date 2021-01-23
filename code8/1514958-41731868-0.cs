        public List<Note> Hotnotes {
            get
            {
                if (Notes == null) {
                    return new List<Note>();
                }
                return Notes.Where(x => x.IsActiveHotnote).OrderByDescending(x => x.Timestamp).ToList();
            }
        }
