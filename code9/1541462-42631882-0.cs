    boolean= false;
		for (int i = 0; i < rays; i++) 
		{
			Vector2 raysStart = raysStart.topLeft + Vector2.right * (raysSpacing * i);
			RaycastHit2D hit = Physics2D.Raycast (raysStart, Vector2.up, 10, checkMask);
			if (hit)
			{                     
				Debug.DrawLine (raysStart, raysStart + Vector2.up * 10, Color.red);
				boolean= true;
			} 
			else if (!hit)
			{                     
				Debug.DrawLine (raysStart, raysStart + Vector2.up * 10, Color.green);
			}
		}
