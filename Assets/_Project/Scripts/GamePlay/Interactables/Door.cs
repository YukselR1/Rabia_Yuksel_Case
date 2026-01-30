using Project.Core.Interaction;
using Project.Core.Inventory;
using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public sealed class Door : MonoBehaviour, IInteractable
    {
        [Header("Lock")]
        [SerializeField] private bool isLocked = true;
        [SerializeField] private ItemData requiredKey;

        [Header("Door State")]
        [SerializeField] private bool isOpen = false;

        [Header("Animation")]
        [SerializeField] private Transform doorVisual;
        [SerializeField] private float openAngle = 90f;

        public InteractionType Type => InteractionType.Toggle;

        public float HoldDuration => 0f;

        public bool CanInteract
        {
            get
            {
                if (!isLocked) return true;
                if (requiredKey == null) return false;

                Inventory inv = FindAnyObjectByType<Inventory>();
                return inv != null && inv.HasItem(requiredKey);
            }
        }

        public string PromptText
        {
            get
            {
                if (isLocked)
                {
                    if (requiredKey == null) return "Locked";
                    return CanInteract
                        ? $"Press E to Unlock ({requiredKey.DisplayName})"
                        : $"Locked - Need {requiredKey.DisplayName}";
                }

                return isOpen ? "Press E to Close Door" : "Press E to Open Door";
            }
        }

        public void Interact()
        {
            // kilitliyse önce unlock et
            if (isLocked)
            {
                if (!CanInteract)
                {
                    Debug.Log("Door is locked. Missing key.");
                    return;
                }

                isLocked = false;
                Debug.Log("Door unlocked!");
                // unlock ettikten sonra otomatik açmak istiyorsan:
                ToggleDoor();
                return;
            }

            ToggleDoor();
        }

        private void ToggleDoor()
        {
            isOpen = !isOpen;

            if (doorVisual == null) doorVisual = transform;

            float targetY = isOpen ? openAngle : 0f;
            Vector3 euler = doorVisual.localEulerAngles;
            doorVisual.localRotation = Quaternion.Euler(0f, targetY, 0f);

            Debug.Log(isOpen ? "Door opened" : "Door closed");
        }

        public void OnHoldStart() { }
        public void OnHoldComplete() { }
        public void OnHoldCancel() { }
    }
}
