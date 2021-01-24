	using UnityEngine;
	public class CameraInput : MonoBehaviour
	{
		[SerializeField] private float rotationAcceleration;
		[SerializeField] private float rotationSpeedMax; // In radians/frame
		[SerializeField] private float rotationDamping; // 0.99
		private float rotationSpeed;
		private void Awake()
		{
			rotationSpeed = rotationSpeedMax / 4;
		}
		private void Update()
		{
			if (Input.GetKey(KeyCode.A))
			{
				rotationSpeed += rotationAcceleration;
			}
			if (Input.GetKey(KeyCode.D))
			{
				rotationSpeed -= rotationAcceleration;
			}
			rotationSpeed = Mathf.Clamp(
                rotationSpeed, -rotationSpeedMax, rotationSpeedMax);
			transform.Rotate(0f, rotationSpeed, 0f);
			rotationSpeed *= rotationDamping;
		}
	}
