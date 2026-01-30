using Project.Core.Interaction;
using Project.Core.Inventory;
using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public sealed class KeyPickup : MonoBehaviour, IInteractable
    {
        [Header("Key")]
        [SerializeField] private ItemData keyItem;

        public string PromptText => keyItem != null ? $"Press E to Pick Up {keyItem.DisplayName}" : "Press E to Pick Up";
        public bool CanInteract => keyItem != null;

        public InteractionType Type => InteractionType.Instant;

        public float HoldDuration => 0f;

        public void Interact()
        {
            Inventory inv = FindAnyObjectByType<Inventory>();
            if (inv == null)
            {
                Debug.LogWarning("Inventory not found in scene!");
                return;
            }

            inv.AddItem(keyItem);
            Debug.Log($"Picked up key: {keyItem.ItemId}");

            Destroy(gameObject);
        }

        public void OnHoldStart() { }
        public void OnHoldComplete() { }
        public void OnHoldCancel() { }
    }
}
