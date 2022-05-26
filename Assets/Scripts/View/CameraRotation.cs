using UnityEngine;

namespace View
{
    public class CameraRotation : MonoBehaviour
    {
        [SerializeField] private Vector2 rotationBorders;
        private Transform _selfTransform;

        private void Awake() => _selfTransform = GetComponent<Transform>();

        public void RotateCamera(float rotateY)
        {
            _selfTransform.eulerAngles += new Vector3(-rotateY, 0);
            var angles = _selfTransform.localEulerAngles;
            angles.x = Mathf.Clamp(angles.x, rotationBorders.x, rotationBorders.y);
            _selfTransform.localEulerAngles = angles;
        }
    }
}