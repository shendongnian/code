    using UnityEngine;
    using System.Collections;
    
    public class CircleDrawing : MonoBehaviour
    {
    	public float Radius = 2f;
    	public int Points = 5;
    	public Color Color = Color.red;
    	public float DrawSpeed = 1f;
    
    	private LineRenderer lineRenderer;
    	private float progress; // [0..1] animated value.
    
    	public void Awake()
    	{
    		lineRenderer = gameObject.AddComponent<LineRenderer>();
    		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
    		lineRenderer.material.color = Color;
    		lineRenderer.startWidth = lineRenderer.endWidth = 0.5f;
    		lineRenderer.positionCount = Points + 2;    //+2 to close the shape and create one more piece to extend over the gap.
    		progress = 0;
    		StartCoroutine(Draw());
    	}
    
    	private void Update_Disabled() // Regular Update() loop
    	{
    		float angle = 0f;
    		for (int i = 0; i <= Points + 1; i++) // one more piece
    		{
    			float x = Radius * Mathf.Cos(angle) + transform.position.x;
    			float y = Radius * Mathf.Sin(angle) + transform.position.y;
    			lineRenderer.SetPosition(i, new Vector3(x, y, 0.01f));
    			angle += (2f * Mathf.PI) / Points;
    			angle *= progress;
    		}
    
    		progress += DrawSpeed * Time.deltaTime;
    		progress = Mathf.Clamp01(progress);
    	}
    
    	private IEnumerator Draw()
    	{
    		yield return new WaitForSeconds(1f); // Debug
    
    		bool done = false;
    		while(!done)
    		{
    			if(progress >= 1)
    				done = true; // The done check can be handled better, but it's late.
    				
    			float angle = 0f;
    			for (int i = 0; i <= Points + 1; i++) // One additional piece to loop over start.
    			{
    				float x = Radius * Mathf.Cos(angle) + transform.position.x;
    				float y = Radius * Mathf.Sin(angle) + transform.position.y;
    				lineRenderer.SetPosition(i, new Vector3(x, y, 0.01f));
    				angle += (2f * Mathf.PI) / Points;
    				angle *= progress; // Animate progress turning.
    			}
    			progress += DrawSpeed * Time.deltaTime;
    			progress = Mathf.Clamp01(progress);
    			yield return null;
    		}
    	}
    }
