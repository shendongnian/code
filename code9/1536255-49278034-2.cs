    private enum Statuses
    {
        Fitted,
        Unfitted,
        Used
    }
    private int GetStatus(int enumstatus)
    {
        return enumstatus = ctx.myStatus.Where(a => a.Enum_mapped == enumstatus).Select(a => a.PK).FirstOrDefault();
    }
