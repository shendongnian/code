    using UnityEngine;
    using System.Collections;
    public class FrustumScript : MonoBehaviour {
    private void Start()
    {
        TriangleMaker();
    }
    void TriangleMaker()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mf.mesh = mesh;
        Camera cam = Camera.main;
        //vertices
        Vector3[] vertices = new Vector3[3]
        {
            new Vector3(0, 0, 0),
            cam.ViewportToWorldPoint(new Vector3(0, 1, cam.farClipPlane)),
            cam.ViewportToWorldPoint(new Vector3(1, 1, cam.farClipPlane))
        };
        //triangles
        int[] tri = new int[6];
        tri[0] = 0; //go clock wise always to make triangle from your vertices
        tri[1] = 1;
        tri[2] = 2;
        //normals
        //show the direction of objects
        Vector3[] normals = new Vector3[3];
        normals[0] = -Vector3.up;
        normals[1] = -Vector3.up;
        normals[2] = -Vector3.up;
        mesh.vertices = vertices;
        mesh.triangles = tri;
        mesh.normals = normals;
    }
    }
