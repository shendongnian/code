    public interface ICashBuddieHelper<T> where T : InputModelBase {
        ICashBuddieHelper<T> FilterOnContext(DbBuddieContext db);
        ICashBuddieHelper<T> PrepareResultModel(T message);
        ICashBuddieHelper<T> SortSet();
        ResultModelBase ToResultModel(T message);
    }
    public class BankAccountInputModel : InputModelBase {
        //...
    }
    public class BankAccountHelper : ICashBuddieHelper<BankAccountInputModel> {
        public ICashBuddieHelper<BankAccountInputModel> FilterOnContext(DbBuddieContext db) { return null; }
        public ICashBuddieHelper<BankAccountInputModel> PrepareResultModel(BankAccountInputModel message) {
            return null;
        }
        public ICashBuddieHelper<BankAccountInputModel> SortSet() { return null; }
        public ResultModelBase ToResultModel(BankAccountInputModel message) {
            return null;
        }
    }
