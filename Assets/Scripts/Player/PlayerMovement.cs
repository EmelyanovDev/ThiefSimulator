using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private Joystick joystick;
        
        private Rigidbody _rigidbody;
        private Transform _selfTransform;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _selfTransform = GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            Vector3 move = _selfTransform.rotation * joystick.Direction;
            move *= Time.deltaTime * movementSpeed;
            _rigidbody.velocity = new Vector3(move.x, _rigidbody.velocity.y, move.z);
        }
    }
}
