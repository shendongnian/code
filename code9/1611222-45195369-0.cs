    interface ICompareById {
        int Id { get; }
    }
    
    class Student : ICompareById {
        int Id { get; set; }
        int StudentId { get { return this.Id; }
    }
    
    class Teacher : ICompareById {
        int Id { get; set; }
        int TeacherId { get { return this.Id; }
    }
    
    class IdComp : IComparer<ICompareById>
    {
        int Compare(ICompareById x, ICompareById y)
        {
            return Comparer<int>.Default.Compare(x.Id, y.Id);
        }
    }
