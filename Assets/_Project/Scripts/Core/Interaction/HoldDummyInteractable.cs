using Project.Core.Interaction;
using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public sealed class HoldDummyInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private string promptText = "Hold E to Complete";
        [SerializeField] private float holdDuration = 2f;

        public string PromptText => promptText;
        public bool CanInteract => true;

        public InteractionType Type => InteractionType.Hold;

        public float HoldDuration => holdDuration;

        public void Interact() { } // hold objesinde kullanýlmaz

        public void OnHoldStart()
        {
            Debug.Log("Hold started on: " + gameObject.name);
        }

        public void OnHoldComplete()
        {
            Debug.Log("Hold complete on: " + gameObject.name);
        }

        public void OnHoldCancel()
        {
            Debug.Log("Hold cancelled on: " + gameObject.name);
        }
    }
}
