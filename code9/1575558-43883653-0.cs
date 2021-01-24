    private void CheckNeighbor(ref Node neighborTile, ref Node currentTile, ref Node targetTile, ref List<Node> closedList, ref List<Node> openList, bool ignoreMoveCost = false){
		if (neighborTile != null) {
			if (!neighborTile.passable || closedList.Contains (neighborTile)) {
			} else {
				int newCostToNeighbor = (int)((ignoreMoveCost ? 1 : neighborTile.moveCost) + currentTile.GetGCost() + CalculateDistance (currentTile.position, neighborTile.position));
				if (!openList.Contains (neighborTile)) {
					openList.Add (neighborTile);
				} else if (newCostToNeighbor >= neighborTile.GetGCost ()) {
					return;
				}
				neighborTile.SetParent (currentTile);
				neighborTile.SetGCost (newCostToNeighbor);
				neighborTile.SetHCost (CalculateDistance (currentTile.position, neighborTile.position));
			}
		}
	}
