	public class HashByID : HashAlgorithm {
		static readonly Type hUtils;
		static readonly SafeHandle hStaticProv;
		static readonly Delegate fCreate, fHash, fHashEnd;
		public static bool inited;
		public readonly int algID;
		SafeHandle hh = null;
		static HashByID() {
			try {
				hUtils = Type.GetType("System.Security.Cryptography.Utils");
				hStaticProv = (SafeHandle)hUtils.GetProperty("StaticProvHandle", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null, null);
				fCreate = hUtils.GetMethods(BindingFlags.NonPublic | BindingFlags.Static).Where(x => x.Name == "CreateHash" && x.GetParameters().Length == 2).Single().CreateDelegate(null);
				fHash = hUtils.GetMethods(BindingFlags.NonPublic | BindingFlags.Static).Where(x => x.Name == "HashData" && x.GetParameters().Length == 4).Single().CreateDelegate(null);
				fHashEnd = hUtils.GetMethods(BindingFlags.NonPublic | BindingFlags.Static).Where(x => x.Name == "EndHash" && x.GetParameters().Length == 1).Single().CreateDelegate(null);
				inited = true;
			} catch { }
		}
		public HashByID(int algID) {
			if (algID == 0x8009) algID = 0x8004;	//map CALG_HMAC -> CALG_SHA1
			this.algID = algID;
			Initialize();
		}
		protected override void Dispose(bool disposing) {
			if (hh != null && !hh.IsClosed) hh.Dispose();
			base.Dispose(disposing);
		}
		public override void Initialize() {
			if (hh != null && !hh.IsClosed) hh.Dispose();
			hh = (SafeHandle)fCreate.DynamicInvoke(hStaticProv, algID);
		}
		protected override void HashCore(byte[] data, int ofs, int len) {
			fHash.DynamicInvoke(hh, data, ofs, len);
		}
		protected override byte[] HashFinal() {
			return (byte[])fHashEnd.DynamicInvoke(hh);
		}
	}
