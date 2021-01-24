	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
    using Some.Namespace.That.Gets.PriorityQueue;
	public class TEST: MonoBehaviour {
		Dictionary<GameObject, List<GameObject>> attachedToWaypoint = new Dictionary<GameObject, List<GameObject>>();
		GameObject[] waypoints;
		GameObject startNode;
		GameObject targetNode;
		GameObject current;
		PriorityQueue<float, GameObject> open = new PriorityQueue<float, GameObject>();
		HashSet<GameObject> closed = new HashSet<GameObject>();
		List<GameObject> path = new List<GameObject>();
		float distanceToEnemy;
		float distanceToPlayer;
		float FCost;
		float GCost;
		float HCost;
		float nodeDistances;
		public GameObject enemy;
		public GameObject player;
		public GameObject parent;
		
		// Use this for initialization
		void Start() {
			distanceToEnemy = 1000;
			distanceToPlayer = 1000;
			nodeDistances = 10000;
			waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
			storeNodesInDictionary();
			findPath();
			// findPathtoPlayer();
			testing();
		}
		
		void storeNodesInDictionary() {
			for (int i = 0; i < waypoints.Length; i++) {
				var waypoint = waypoints[i];
				var nodeData = new List<GameObject>();
				var waypointPosition = waypoint.transform.position;
				float distEnemy = Vector3.Distance(enemy.transform.position, waypointPosition); // Closest node to enemy
				if (distEnemy < distanceToEnemy) {
					startNode = waypoint;
					distanceToEnemy = distEnemy;
				}
				float distPlayer = Vector3.Distance(player.transform.position, waypointPosition); // Closest node to player
				if (distPlayer < distanceToPlayer) {
					targetNode = waypoint;
					distanceToPlayer = distPlayer;
				}
				for (int j = 0; j < waypoints.Length; j++) {
					if (i == j)
						continue;
					var otherWaypoint = waypoints[j];
					float distanceSqr = (waypointPosition - otherWaypoint.transform.position).sqrMagnitude; // Gets distance values
					if (distanceSqr < 60) // Is waypoints are within a spcific distance
					{
						nodeData.Add(otherWaypoint);
					}
				}
				attachedToWaypoint.Add(waypoint, nodeData); // Adds parent node and neighbouring nodes within a 3x3 grid
			}
		}
		
		void findPath() {
			var startPosition = startNode.transform.position;
			var targetPosition = targetNode.transform.position;
			open.Push(Vector3.Distance(startPosition, targetPosition), startNode);
			while (open.Count > 0) {
				FCost = open.Pop(out current);
				var currentPosition = current.transform.position;
				if (currentPosition == targetPosition) {
					Debug.Log("Goal reached");
					break;
				}
				HCost = Vector3.Distance(currentPosition, targetPosition);
				GCost = FCost - HCost;
				closed.Add(current);
				var neighbours = attachedToWaypoint[current];
				// path.Add(current);
				foreach(GameObject n in neighbours) {
					if (!closed.Contains(n) && !open.Contains(n)) // If 'open' list does not currently contain neighbour or neighbours F score is smaller than that of the current node
					{
						var neighbourPosition = n.transform.position;
						var neighbourFCost = GCost + Vector3.Distance(currentPosition, neighbourPosition) + Vector3.Distance(neighbourPosition, targetPosition)
						open.Push(neighbourFCost, n); // if neighbour is not in open list, add to open list
					}
				}
			}
		}
	}
