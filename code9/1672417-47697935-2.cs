    public class JobTypeList : ObservableCollection<JobType>
    {
        public void SortJobTypes()
        {
            var sortableList = new List<JobType>(this);
            sortableList.Sort((x, y) => x.Name.CompareTo(y.Name));
            //this works but it creates a bug in the select for JobTypes
            for(int i = 0; i < sortableList.Count; i++)
            {
                this.Move(this.IndexOf(sortableList[i]), i);
            }
        }
    }
