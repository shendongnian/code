    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;
    
    [RequireComponent (typeof(Rigidbody))]
    public class DragEnabledShape : MonoBehaviour {
    
    	const float EPSILON = 0.0001f;
    
    	public Voxel voxelPrefab;
    	public float C = 1f;
    	public float d = 0.5f;
    	public int resolutionFactor = 2;
    	public float maxDistanceFromCenter = 10f;
    	public bool displayDragVisualization = false;
    	public float forceVisualizationMultiplier = 1f;
    	public bool displayVoxels = false;
    	public bool loadCustomVoxels = false;
    
    	List<Voxel> voxels;
    	Rigidbody rb;
    
    
    	// Use this for initialization
    	void Awake () {
    		voxels = new List<Voxel> ();
    		rb = GetComponent<Rigidbody> ();
    	}
    
    	void OnEnable () {
    
    		if (loadCustomVoxels) {
    			var customVoxels = GetComponentsInChildren<Voxel> ();
    			voxels.AddRange (customVoxels);
    			if (displayDragVisualization) {
    				foreach (Voxel voxel in customVoxels) {
    					voxel.DisplayDrag (forceVisualizationMultiplier);
    				}
    			}
    			if (displayVoxels) {
    				foreach (Voxel voxel in customVoxels) {
    					voxel.Display ();
    				}
    			}
    		}
    		else {
    			foreach (Transform child in GetComponentsInChildren<Transform> ()) {
    				if (child.GetComponent<Collider> ()) {
    					//print ("creating voxels of " + child.gameObject.name);
    					CreateSurfaceVoxels (child);
    				}
    			}
    		}
    	}
    
    	void CreateSurfaceVoxels (Transform body) {
    		List<Vector3> directionList = new List<Vector3> ();
    		for (float i = -1; i <= 1 + EPSILON; i += 2f / resolutionFactor) {
    			for (float j = -1; j <= 1 + EPSILON; j += 2f / resolutionFactor) {
    				for (float k = -1; k <= 1 + EPSILON; k += 2f / resolutionFactor) {
    					Vector3 v = new Vector3 (i, j, k);
    					directionList.Add (v);
    				}
    			}
    		}
    		//float runningTotalVoxelArea = 0;
    		foreach (Vector3 direction in directionList) {
    			Ray upRay = new Ray (body.position, direction).Reverse (maxDistanceFromCenter);
    			RaycastHit[] hits = Physics.RaycastAll (upRay, maxDistanceFromCenter);
    			if (hits.Length > 0) {
    				//print ("Aiming for " + body.gameObject.name + "and hit count: " + hits.Length); 
    				foreach (RaycastHit hit in hits) {
    					
    					if (hit.collider == body.GetComponent<Collider> ()) {
    						//if (GetComponentsInParent<Transform> ().Contains (hit.transform)) {
    						//print ("hit " + body.gameObject.name);  
    						GameObject empty = new GameObject ();
    						empty.name = "Voxels";
    						empty.transform.parent = body;
    						empty.transform.localPosition = Vector3.zero;
    						GameObject newVoxelObject = Instantiate (voxelPrefab.gameObject, empty.transform);
    						Voxel newVoxel = newVoxelObject.GetComponent<Voxel> ();
    						voxels.Add (newVoxel);
    						newVoxel.transform.position = hit.point;
    						newVoxel.transform.rotation = Quaternion.LookRotation (hit.normal);
    						newVoxel.DetermineTotalSurfaceArea (hit.distance - maxDistanceFromCenter, resolutionFactor);
    						newVoxel.attachedToCollider = body.GetComponent<Collider> ();
    						if (displayDragVisualization) {
    							newVoxel.DisplayDrag (forceVisualizationMultiplier);
    						}
    						if (displayVoxels) {
    							newVoxel.Display ();
    						}
    						//runningTotalVoxelArea += vox.TotalSurfaceArea;
    						//newVoxel.GetComponent<FixedJoint> ().connectedBody = shape.GetComponent<Rigidbody> ();
    					}
    					else {
    						//print ("missed " + body.gameObject.name + "but hit " + hit.transform.gameObject.name); 
    					}
    				}
    
    
    			}
    
    		}
    
    	}
    
    	void FixedUpdate () {
    		foreach (Voxel voxel in voxels) {
    			rb.AddForceAtPosition (voxel.GetDrag (), voxel.transform.position);
    		}
    	}
    		
    
    
    }
