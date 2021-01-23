        [NotMapped]
        private Subject _subject
        public Subject Subject
        {
            get
            {
                if (this._subject == null)
                    this._subject = QueryAPI(this.SubjectId);
                return this._subject;
            }
            set;
        }
