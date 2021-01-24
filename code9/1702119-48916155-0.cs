    class Leader<TFollower> 
    {
        public TFollower Slave;
    }
    class Follower<TLeader>
    {
        public TLeader Master; 
    }
    
    class Teacher : Leader<Student>
    {
    }
    class Student : Follower<Teacher>
    {
    }
    class Officer : Leader<Soldier>
    {
    }
    class Soldier : Follower<Officer>
    {
    }
