    using UnityEngine;
    public class RotateObject : MonoBehaviour
    {
    public float RotationSpeedX;
    public float RotationSpeedY;
    public float RotationSpeedZ;
    private float Axis = 0;
    public void Update()
    {
        Vector3 RotationSPD = new Vector3(RotationSpeedX, RotationSpeedY, RotationSpeedZ);
        Rotate_Object(RotationSPD);
    }
    private void Rotate_Object (Vector3 Rotation_Speed)
    {
        transform.Rotate(Rotation_Speed * Time.deltaTime);
      }
    }
