	public static IObservable<UdpReceiveResult> UdpStream()
	{
		return
			Observable
				.Using(
					() =>
					{
						UdpClient receiverUDP = new UdpClient();
						receiverUDP.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
						receiverUDP.EnableBroadcast = true;
						receiverUDP.Client.ExclusiveAddressUse = false;
						receiverUDP.Client.Bind(new IPEndPoint(IPAddress.Any, 514));
						return receiverUDP;
					},
					udpClient =>
						Observable
							.Defer(() =>
								Observable
									.FromAsync(() => udpClient.ReceiveAsync()))
							.Repeat());
	}
