    public class MessageInfo{
        public byte[] Message;
    }
    var result = await db.Database
        .SqlQuery<MessageInfo>("SELECT MESSAGE FROM FOCUS.ENTRIES")
        .ToListAsync();
    var list = result.Select( x => x.Message );
