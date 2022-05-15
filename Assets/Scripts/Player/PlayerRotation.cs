using Camera;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        
        private Transform _selfTransform;
        private CameraRotation _cameraRotation;

        private void Awake()
        {
            _selfTransform = GetComponent<Transform>();
            _cameraRotation = GetComponentInChildren<CameraRotation>();
        }

        private void OnEnable() => RotationPanel.OnPointerDrag += Rotate;

        private void OnDisable() => RotationPanel.OnPointerDrag -= Rotate;

        private void Rotate(Vector2 touchDelta)
        {
            Vector2 rotate = touchDelta * Time.deltaTime * rotationSpeed;
            _selfTransform.localEulerAngles += new Vector3(0, rotate.x);
            _cameraRotation.RotateCamera(rotate.y);
        }
    }
}