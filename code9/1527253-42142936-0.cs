    public class DictionaryKeyList {
        public List<string> Lst { get; set; }
        public override bool Equals(Object otherObj){
            var otherList = otherObj as DictionaryKeyList;
            return !this.Lst.Zip(otherList, (a,b) => a == b).Any(x => !x);
        }
