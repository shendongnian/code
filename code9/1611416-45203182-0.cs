	class DynamicGroup<TKey, TElement> : DynamicObject, IGrouping<TKey, TElement> {
		private string keyname;
		private IGrouping<TKey, TElement> items;
		public DynamicGroup(IGrouping<TKey, TElement> pItems, string pKeyname) {
			items = pItems;
			keyname = pKeyname;
		}
		public IEnumerator<TElement> GetEnumerator() => items.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		public TKey Key { get => items.Key; }
		public override bool TryGetMember(GetMemberBinder binder, out object result) {
			if (binder.Name == keyname) {
				result = items.Key;
				return true;
			}
			else {
				result = null;
				return false;
			}
		}
	}
	static class Ext {
		public static IEnumerable<dynamic> NamedGroupBy<TElement, TKey>(this IEnumerable<TElement> src, Expression<Func<TElement, TKey>> keySelector) {
			var ksb = keySelector.Body as MemberExpression;
			return src.GroupBy(keySelector.Compile()).Select(g => new DynamicGroup<TKey, TElement>(g, ksb.Member.Name));
		}
	}
