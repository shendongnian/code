    public enum TeacherType
    {
        TeacherAlchemist,
        TeacherBlacksmith,
        TeacherBowyer,
        TeacherButcher,
        TeacherHunter,
        TeacherInnkeeper,
        TeacherJuggler,
        TeacherMessenger,
        TeacherPriest,
        TeacherTamer,
        TeacherThief,
        TeacherTownGuard
    }
    public TeacherType type;
    private NpcTeacherData teacherData;
    private void Start()
    {
        switch (type)
        {
            case "TeacherType.TeacherAlchemist":
                teacherData = new TeacherAlchemist();
                break;
            //...
        }
    }
