	var gameStartButton = new UIButton(UIButtonType.System);
	gameStartButton.Frame = new CoreGraphics.CGRect(40, 40, 100, 40);
	gameStartButton.SetTitle("Start Game", UIControlState.Normal);
	gameStartButton.TouchUpInside += (object sender, EventArgs e) =>
	{
		GKLocalPlayer.LocalPlayer.AuthenticateHandler = async (UIViewController uiViewController, Foundation.NSError error) =>
		{
			if (uiViewController != null)
			{
				await PresentViewControllerAsync(uiViewController, true);
			}
			if (GKLocalPlayer.LocalPlayer.Authenticated)
			{
				Console.WriteLine($"{GKLocalPlayer.LocalPlayer.PlayerID} : {GKLocalPlayer.LocalPlayer.Authenticated}");
				Console.WriteLine("Call a start game method...");
			}
		};
	};
	Add(gameStartButton);
