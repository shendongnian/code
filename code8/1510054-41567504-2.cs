    private class RepoElement: IComparable<MyData>
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public DateTime Date {get; set;}
        public int CompareTo(RepoElement other)
        {   // this object smaller than other object
            // if this date smaller than other date
            return this.Date.CompareTo(other.Date);
        }
    }
    var result = repo
        .Where(repoElement => repoElement.Id == someId)
        .Select( result1 => new RepoElement[]
        {
            repo.Where(repoElement => repoElement.Date < result1.Date).Max(),
            repoElement,
            repo.Where(repoElement => repoElement.Date > result1.Date).Min(),
        }
