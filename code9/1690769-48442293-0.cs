	public interface IInventoryItem {}
	public class      InventoryItem : IInventoryItem {}
	public interface IInventory<T> where T : IInventoryItem
	{
		IEnumerable<T> Items { get; } 
	}
    
	public class Inventory : IInventory<InventoryItem>
	{
		public  IEnumerable<InventoryItem>  Items            => items;
		//      IEnumerable<IInventoryItem> IInventory.Items => items;
    
		private InventoryItem[] items = new InventoryItem[0];
	}
