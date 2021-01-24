    // written by 'imerso' as a StackOverflow answer.
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class SlopeTerrain : MonoBehaviour
    {
    	public int heightInMeters = 5;
    	public int widthInMeters = 128;
    	public float ondulationFactor = 0.1f;
    	public Material material;
    
    	// Use this for initialization
    	void Start ()
    	{
    		Mesh mesh = new Mesh();
    		List<Vector3> vertices = new List<Vector3>();
    		List<int> triangles = new List<int>();
    
    		for (int p = 0; p < widthInMeters; p++)
    		{
    			// add two vertices, one at the horizontal position but displaced by a sine wave,
    			// and other at the same horizontal position, but at bottom
    			vertices.Add(new Vector3(p, Mathf.Abs(heightInMeters * Mathf.Sin(p * ondulationFactor)), 0));
    			vertices.Add(new Vector3(p, 0, 0));
    
    			if (p > 0)
    			{
    				// we have enough vertices created already,
    				// so start creating triangles using the previous vertices indices
    				int v0 = p * 2 - 2;			// first sine vertex
    				int v1 = p * 2 - 1;			// first bottom vertex
    				int v2 = p * 2;				// second sine vertex
    				int v3 = p * 2 + 1;			// second bottom vertex
    
    				// first triangle
    				triangles.Add(v0);
    				triangles.Add(v1);
    				triangles.Add(v2);
    
    				// second triangle
    				triangles.Add(v2);
    				triangles.Add(v1);
    				triangles.Add(v3);
    			}
    		}
    
    		mesh.vertices = vertices.ToArray();
    		mesh.triangles = triangles.ToArray();
    
    		mesh.RecalculateBounds();
    
    		MeshRenderer r = gameObject.AddComponent<MeshRenderer>();
    		MeshFilter f = gameObject.AddComponent<MeshFilter>();
    
    		if (material != null)
    		{
    			r.sharedMaterial = material;
    		}
    
    		f.sharedMesh = mesh;
    	}
    }
