using UnityEngine;

namespace Project.Core.Player
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float gravity = -20f;

        private CharacterController _characterController;
        private Vector3 _velocity;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            // WASD input
            float x = Input.GetAxisRaw("Horizontal"); // A/D
            float z = Input.GetAxisRaw("Vertical");   // W/S

            Vector3 move = (transform.right * x) + (transform.forward * z);
            move = Vector3.ClampMagnitude(move, 1f);

            _characterController.Move(move * (moveSpeed * Time.deltaTime));

            // Simple gravity
            if (_characterController.isGrounded && _velocity.y < 0f)
            {
                _velocity.y = -2f; // küçük yapýþma
            }

            _velocity.y += gravity * Time.deltaTime;
            _characterController.Move(_velocity * Time.deltaTime);
        }
    }
}
