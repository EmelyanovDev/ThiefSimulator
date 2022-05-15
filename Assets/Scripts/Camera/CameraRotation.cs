using UnityEngine;

namespace Camera
{
    public class CameraRotation : MonoBehaviour
    {
        private Transform _selfTransform;

        private void Awake() => _selfTransform = GetComponent<Transform>();

        public void RotateCamera(float rotateY)
        {
            _selfTransform.localEulerAngles += new Vector3(-rotateY, 0);
        }
    }
}