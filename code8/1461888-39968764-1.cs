	Subject<RoleplayInstance> requestTaxi = new Subject<RoleplayInstance>();
	IDisposable subscription =
		requestTaxi
			.Select(ri =>
				ri == null
				? Observable.Never<RoleplayInstance>()
				: Observable
					.Timer(TimeSpan.FromSeconds((double)ri.TaxiWaitTimeSeconds))
					.Select(n => ri))
			.Switch()
			.Subscribe(ri =>
			{
				GameClient gameSession = ri.GetSession();
				Room currentRoom = gameSession.GetHabbo().CurrentRoom;
				RoomUser roomUser = currentRoom.GetRoomUserManager().GetRoomUserByHabbo(gameSession.GetHabbo().Id);
				currentRoom.SendMessage(new ShoutComposer(roomUser.VirtualId, "*Gets transported to my destination*", 0, roomUser.LastBubble));
				gameSession.GetHabbo().PrepareRoom(roleplayInstance.TaxiRoomId, string.Empty);
			});
