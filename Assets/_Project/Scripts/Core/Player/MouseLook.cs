using UnityEngine;

namespace Project.Core.Player
{
    public sealed class MouseLook : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform cameraPivot; // CameraRig

        [Header("Look")]
        [SerializeField] private float sensitivity = 2f;
        [SerializeField] private float minPitch = -80f;
        [SerializeField] private float maxPitch = 80f;

        private float _pitch;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            // Yaw: player döner
            transform.Rotate(Vector3.up * mouseX);

            // Pitch: kamera yukarý-aþaðý
            _pitch -= mouseY;
            _pitch = Mathf.Clamp(_pitch, minPitch, maxPitch);

            if (cameraPivot != null)
            {
                cameraPivot.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
            }
        }
    }
}
