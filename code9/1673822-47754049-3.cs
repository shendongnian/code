	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	public static class RotationHelper {
		public static Vector3 ConvertYawPitch(Vector3 vector, float yaw, float pitch)
		{
			Quaternion yawRotation = Quaternion.AngleAxis (yaw, Vector3.up);
			Vector3 yawedZAxis = yawRotation * Vector3.left;
			Quaternion pitchRotation = Quaternion.AngleAxis (pitch, yawedZAxis);
			Vector3 yawedVector = yawRotation * vector;
			Vector3 position = pitchRotation * yawedVector;
			return position;
		}
	}
