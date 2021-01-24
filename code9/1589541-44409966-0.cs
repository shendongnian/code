    using UnityEngine;
    [RequireComponent(typeof(CapsuleCollider))]
    public class LaserBeam : MonoBehaviour
    {
        public LayerMask wallLayers;
        public float speedOfLight = 1f;
        private Vector3 reflectionTestPointLocal, completeIntrusionTestPointLocal;
        private float beamLengthLocal;
        private bool didSpawnReflection;
        void Start()
        {
            CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();
            beamLengthLocal = capsuleCollider.height;
            reflectionTestPointLocal = Vector3.up * beamLengthLocal * .5f;
            completeIntrusionTestPointLocal = -Vector3.up * beamLengthLocal * .5f;
        }
        void Update()
        {
            float stepLength = speedOfLight * Time.deltaTime;
            Vector3 step = transform.up * stepLength;
            if (!didSpawnReflection)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.TransformPoint(reflectionTestPointLocal), step, out hit, stepLength, wallLayers))
                {
                    SpawnReflection(hit.point, hit.normal);
                    didSpawnReflection = true;
                }
            }
            if (didSpawnReflection)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.TransformPoint(completeIntrusionTestPointLocal), step, out hit, stepLength, wallLayers))
                {
                    Destroy(gameObject);
                    return;
                }
            }
            transform.position += step;
        }
        private void SpawnReflection(Vector3 pointOfReflection, Vector3 reflectionNormal)
        {
            float impactAngle = Vector3.Angle(-transform.up, reflectionNormal);
            Vector3 impactTangent = Vector3.Cross(-transform.up, reflectionNormal);
            Quaternion reflectedRotation = Quaternion.AngleAxis(180 + impactAngle * 2, impactTangent) * transform.rotation;
            LaserBeam reflectedBeam = Instantiate(this);
            reflectedBeam.gameObject.name = gameObject.name;
            reflectedBeam.transform.parent = transform.parent;
            reflectedBeam.transform.localScale = transform.localScale;
            reflectedBeam.transform.rotation = reflectedRotation;
            reflectedBeam.transform.position = pointOfReflection - reflectedBeam.transform.TransformVector(Vector3.up * beamLengthLocal * .5f);
        }
    }
