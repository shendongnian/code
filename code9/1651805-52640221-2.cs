	public class HashByID : HashAlgorithm {
		static readonly Dictionary<int, int> hashSizes = new Dictionary<int,int>() { {0x8001,128},{0x8002,128},{0x8003,128},{0x8004,160},{0x8006,128},{0x8007,160},{0x800c,256},{0x800d,384},{0x800e,512}};
		static readonly Type hUtils;
		static readonly SafeHandle hStaticProv;
		static readonly Func<SafeHandle, int, SafeHandle> fCreate;
		static readonly Action<SafeHandle, byte[], int, int> fHash;
		static readonly Func<SafeHandle, byte[]> fHashEnd;
		public static bool inited;
		public readonly int algID;
		SafeHandle hh = null;
		static HashByID() {
			try {
				hUtils = Type.GetType("System.Security.Cryptography.Utils");
				hStaticProv = (SafeHandle)hUtils.GetProperty("StaticProvHandle", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null, null);
				fCreate = (Func<SafeHandle, int, SafeHandle>)hUtils.GetMethods(BindingFlags.NonPublic | BindingFlags.Static).Where(x => x.Name == "CreateHash" && x.GetParameters().Length == 2).Single().CreateDelegate(null, typeof(SafeHandle), typeof(int), typeof(SafeHandle));
				fHash = (Action<SafeHandle, byte[], int, int>)hUtils.GetMethods(BindingFlags.NonPublic | BindingFlags.Static).Where(x => x.Name == "HashData" && x.GetParameters().Length == 4).Single().CreateDelegate(null, typeof(SafeHandle), typeof(byte[]), typeof(int), typeof(int));
				fHashEnd = (Func<SafeHandle, byte[]>)hUtils.GetMethods(BindingFlags.NonPublic | BindingFlags.Static).Where(x => x.Name == "EndHash" && x.GetParameters().Length == 1).Single().CreateDelegate(null, typeof(SafeHandle), typeof(byte[]));
				inited = true;
			} catch { }
		}
		public HashByID(int algID) {
			if (algID == 0x8009) algID = 0x8004;	//map CALG_HMAC -> CALG_SHA1
			this.algID = algID;
			hashSizes.TryGetValue(algID, out HashSizeValue);
			Initialize();
		}
		protected override void Dispose(bool disposing) {
			if (hh != null && !hh.IsClosed) hh.Dispose();
			base.Dispose(disposing);
		}
		public override void Initialize() {
			if (hh != null && !hh.IsClosed) hh.Dispose();
			hh = fCreate(hStaticProv, algID);
		}
		protected override void HashCore(byte[] data, int ofs, int len) {
			fHash(hh, data, ofs, len);
		}
		protected override byte[] HashFinal() {
			return fHashEnd(hh);
		}
	}
	
	//Delegate creation helper
	public static Delegate CreateDelegate(this MethodInfo methodInfo, object target, params Type[] custTypes) {
		Func<Type[], Type> getType;
		bool isAction = methodInfo.ReturnType.Equals((typeof(void))), cust = custTypes.Length > 0;
		Type[] types = cust ? custTypes : methodInfo.GetParameters().Select(p => p.ParameterType).ToArray();
		if (isAction) getType = Expression.GetActionType;
		else {
			getType = Expression.GetFuncType;
			if (!cust) types = types.Concat(new[] { methodInfo.ReturnType }).ToArray();
		}
		if (cust) {
			int i, nargs = types.Length - (isAction ? 0 : 1);
			var dm = new DynamicMethod(methodInfo.Name, isAction ? typeof(void) : types.Last(), types.Take(nargs).ToArray(), typeof(object), true);
			var il = dm.GetILGenerator();
			for (i = 0; i < nargs; i++)
				il.Emit(OpCodes.Ldarg_S, i);
			il.Emit(OpCodes.Call, methodInfo);
			il.Emit(OpCodes.Ret);
			if (methodInfo.IsStatic) return dm.CreateDelegate(getType(types));
			return dm.CreateDelegate(getType(types), target);
		}
		if (methodInfo.IsStatic) return Delegate.CreateDelegate(getType(types), methodInfo);
		return Delegate.CreateDelegate(getType(types), target, methodInfo.Name);
	}
