    public Transform[] Corners;
    public Transform lookTarget;
    public bool drawNearCone, drawFrustum;
 
    Camera theCam;
 
    void Start () {
        theCam = camera;
    }
 
    void Update () {
        Vector3 pa, pb, pc, pd;
        pa = Corners[0].position; //Bottom-Left
        pb = Corners[1].position; //Bottom-Right
        pc = Corners[2].position; //Top-Left
        pd = Corners[3].position; //Top-Right
 
        Vector3 pe = theCam.transform.position;// eye position
 
        Vector3 vr = ( pb - pa ).normalized; // right axis of screen
        Vector3 vu = ( pc - pa ).normalized; // up axis of screen
        Vector3 vn = Vector3.Cross( vr, vu ).normalized; // normal vector of screen
 
        Vector3 va = pa - pe; // from pe to pa
        Vector3 vb = pb - pe; // from pe to pb
        Vector3 vc = pc - pe; // from pe to pc
        Vector3 vd = pd - pe; // from pe to pd
 
        float n = -lookTarget.InverseTransformPoint( theCam.transform.position ).z; // distance to the near clip plane (screen)
        float f = theCam.farClipPlane; // distance of far clipping plane
        float d = Vector3.Dot( va, vn ); // distance from eye to screen
        float l = Vector3.Dot( vr, va ) * n / d; // distance to left screen edge from the 'center'
        float r = Vector3.Dot( vr, vb ) * n / d; // distance to right screen edge from 'center'
        float b = Vector3.Dot( vu, va ) * n / d; // distance to bottom screen edge from 'center'
        float t = Vector3.Dot( vu, vc ) * n / d; // distance to top screen edge from 'center'
 
        Matrix4x4 p = new Matrix4x4(); // Projection matrix
        p[0, 0] = 2.0f * n / ( r - l );
        p[0, 2] = ( r + l ) / ( r - l );
        p[1, 1] = 2.0f * n / ( t - b );
        p[1, 2] = ( t + b ) / ( t - b );
        p[2, 2] = ( f + n ) / ( n - f );
        p[2, 3] = 2.0f * f * n / ( n - f );
        p[3, 2] = -1.0f;
 
        theCam.projectionMatrix = p; // Assign matrix to camera
 
        if ( drawNearCone ) { //Draw lines from the camera to the corners f the screen
            Debug.DrawRay( theCam.transform.position, va, Color.blue );
            Debug.DrawRay( theCam.transform.position, vb, Color.blue );
            Debug.DrawRay( theCam.transform.position, vc, Color.blue );
            Debug.DrawRay( theCam.transform.position, vd, Color.blue );
        }
 
        if ( drawFrustum ) DrawFrustum( theCam ); //Draw actual camera frustum
 
    }
 
    Vector3 ThreePlaneIntersection ( Plane p1, Plane p2, Plane p3 ) { //get the intersection point of 3 planes
        return ( ( -p1.distance * Vector3.Cross( p2.normal, p3.normal ) ) +
                ( -p2.distance * Vector3.Cross( p3.normal, p1.normal ) ) +
                ( -p3.distance * Vector3.Cross( p1.normal, p2.normal ) ) ) /
            ( Vector3.Dot( p1.normal, Vector3.Cross( p2.normal, p3.normal ) ) );
    }
 
    void DrawFrustum ( Camera cam ) {
        Vector3[] nearCorners = new Vector3[4]; //Approx'd nearplane corners
        Vector3[] farCorners = new Vector3[4]; //Approx'd farplane corners
        Plane[] camPlanes = GeometryUtility.CalculateFrustumPlanes( cam ); //get planes from matrix
        Plane temp = camPlanes[1]; camPlanes[1] = camPlanes[2]; camPlanes[2] = temp; //swap [1] and [2] so the order is better for the loop
 
        for ( int i = 0; i < 4; i++ ) {
            nearCorners[i] = ThreePlaneIntersection( camPlanes[4], camPlanes[i], camPlanes[( i + 1 ) % 4] ); //near corners on the created projection matrix
            farCorners[i] = ThreePlaneIntersection( camPlanes[5], camPlanes[i], camPlanes[( i + 1 ) % 4] ); //far corners on the created projection matrix
        }
 
        for ( int i = 0; i < 4; i++ ) {
            Debug.DrawLine( nearCorners[i], nearCorners[( i + 1 ) % 4], Color.red, Time.deltaTime, false ); //near corners on the created projection matrix
            Debug.DrawLine( farCorners[i], farCorners[( i + 1 ) % 4], Color.red, Time.deltaTime, false ); //far corners on the created projection matrix
            Debug.DrawLine( nearCorners[i], farCorners[i], Color.red, Time.deltaTime, false ); //sides of the created projection matrix
        }
    }
