	public abstract class UpgradeValueWrapper { }
	public class UpgradeIntValue : UpgradeValueWrapper {
		public int value;
		public UpgradeIntValue(int v) {
			value = v;
		}
	}
	public class UpgradeFloatValue : UpgradeValueWrapper {
		public float value;
		public UpgradeFloatValue(float v) {
			value = v;
		}
	}
