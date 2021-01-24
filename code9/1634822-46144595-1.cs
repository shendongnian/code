    using UnityEngine;
    using System.Collections;
    
    public abstract class MovingObjects : MonoBehaviour {
    
    	public float moveTime = 0.1f;
    	public LayerMask blockingLayer;
    
    	private BoxCollider2D boxCollider;
    	private Rigidbody2D rb2D;
    	private float inverseMoveTime;
    
    	protected virtual void Start()
    	{
    		boxCollider = GetComponent<BoxCollider2D> ();
    		rb2D = GetComponent <Rigidbody2D>();
    		inverseMoveTime = 1f / moveTime;
    
    	}
    
    
    	protected IEnumerator SmoothMovement(Vector3 end)
    	{
    		float sqrRemaininDistance = (transform.position - end).sqrMagnitude;
    
    		while (sqrRemaininDistance > float.Epsilon) {
    
    			Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime*Time.deltaTime);
    
    			rb2D.MovePosition(newPosition);
    			sqrRemaininDistance = (transform.position - end).sqrMagnitude;
    
    			yield return null;
    		}
    	}
    
    	protected bool Move(int xDir, int yDir, out RaycastHit2D hit)
    	{
    		Vector2 start = transform.position;
    		Vector2 end = start + new Vector2 (xDir, yDir);
    
    		boxCollider.enabled = false;
    
    		hit = Physics2D.Linecast (start, end, blockingLayer);
    
    		boxCollider.enabled = true;
    
    		if (hit.transform == null) {
    
    			StartCoroutine(SmoothMovement(end));
    			return true;
    		}
    
    		return false;
    	}
    
    	protected virtual void AttemptMove<T>(int xDir, int yDir)
    							where T : Component
    	{
    
    		RaycastHit2D hit;
    		bool canMove = Move (xDir, yDir, out hit);
    
    		if (hit.transform == null)
    			return;
    
    
    		Debug.Log ("Something hit", gameObject);
    
    		T hitComponent = hit.transform.GetComponent<T> ();
    
    		if (!canMove && hitComponent != null)
    			onCantMove (hitComponent);
    
    
    	}
    
    	protected abstract void onCantMove<T>(T component)
    					   where T: Component;
    
    }
