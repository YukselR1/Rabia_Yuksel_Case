using Project.Core.Interaction;
using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public sealed class DummyInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private string promptText = "Press E to Say Hi";

        public string PromptText => promptText;
        public bool CanInteract => true;

        public InteractionType Type => InteractionType.Instant;

        public float HoldDuration => 0f;

        public void Interact()
        {
            Debug.Log("Hello! Interacted with: " + gameObject.name);
        }

        public void OnHoldStart() { }
        public void OnHoldComplete() { }
        public void OnHoldCancel() { }
    }
}
