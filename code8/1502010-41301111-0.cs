	  	public class collectionViewFlowLayout : UICollectionViewDelegateFlowLayout
	{
		public CoreGraphics.CGSize cellsize;
		public collectionViewFlowLayout(CoreGraphics.CGSize cSize)
		{
			this.cellsize = cSize;
		}
		public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
		{
			return cellsize;
		}
	
