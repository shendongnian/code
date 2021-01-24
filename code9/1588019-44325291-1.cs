	[Serializable]
	public class ItemObject : ISerializationCallbackReceiver
	{
		public void OnAfterDeserialize()
		{
			sprite = Resources.Load<Sprite>("items/" + slug);
			Debug.Log(String.Format("Loaded {0} from {1}", sprite, slug));
		}
		public void OnBeforeSerialize() { }
		(...)
	}
