		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			if (player.Status == AVPlayerStatus.ReadyToPlay)
			{
				Console.WriteLine("Ready to play");
				player.Play();
			}
		}
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (RFVideoTBC)tableView.DequeueReusableCell(RFVideoTBC.Identifier(), indexPath);
			player = AVPlayer.FromUrl(NSUrl.FromString("http://techslides.com/demos/sample-videos/small.mp4"));
			var layer = AVPlayerLayer.FromPlayer(player);
			layer.BackgroundColor = UIColor.Clear.CGColor;
			layer.VideoGravity = AVLayerVideoGravity.ResizeAspect;
			layer.Frame = new CoreGraphics.CGRect(16,
												  75,
												  cell.Frame.Width - 32,
												  200);
			cell.ContentView.Layer.AddSublayer(layer);
			return cell;
		}
