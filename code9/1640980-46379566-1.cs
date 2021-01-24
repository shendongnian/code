    	public class DynamicJsonEntry : DynamicObject {
		private string _JsonName;
		public object Element { get; set; }
		public DynamicJsonEntry(string pJsonName, object pElement) : this(pJsonName) {
			Element = pElement;
		}
		public DynamicJsonEntry(string pJsonName) {
			if(string.IsNullOrWhiteSpace(pJsonName)) {
				throw new ArgumentNullException(nameof(pJsonName));
			}
			_JsonName = pJsonName;
		}
		public override IEnumerable<string> GetDynamicMemberNames() {
			yield return _JsonName;
			foreach(var prop in GetType().GetProperties().Where(a => a.CanRead && a.GetIndexParameters().Length == 0 && a.Name != nameof(Element))) {
				yield return prop.Name;
			}
		}
		public override bool TryGetMember(GetMemberBinder pBinder, out object pResult) {
			if(pBinder.Name == _JsonName) {
				pResult = Element;
				return true;
			}
			return base.TryGetMember(pBinder, out pResult);
		}
	}
