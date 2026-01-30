using Project.Core.Interaction;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Gameplay.Interactables
{
    public sealed class Switch : MonoBehaviour, IInteractable
    {
        [Header("Switch")]
        [SerializeField] private bool isOn = false;

        [Header("Events")]
        [SerializeField] private UnityEvent onSwitchOn;
        [SerializeField] private UnityEvent onSwitchOff;

        public InteractionType Type => InteractionType.Toggle;
        public float HoldDuration => 0f;

        public bool CanInteract => true;

        public string PromptText => isOn ? "Press E to Turn Off" : "Press E to Turn On";

        public void Interact()
        {
            isOn = !isOn;

            if (isOn)
            {
                onSwitchOn?.Invoke();
                Debug.Log("Switch ON");
            }
            else
            {
                onSwitchOff?.Invoke();
                Debug.Log("Switch OFF");
            }
        }

        public void OnHoldStart() { }
        public void OnHoldComplete() { }
        public void OnHoldCancel() { }
    }
}
