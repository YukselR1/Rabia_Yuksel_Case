using Project.UI;
using UnityEngine;

namespace Project.Core.Interaction
{
    public sealed class InteractionDetector : MonoBehaviour
    {
        [Header("Raycast")]
        [SerializeField] private Camera playerCamera;
        [SerializeField] private float range = 3f;
        [SerializeField] private LayerMask interactableMask = ~0;

        [Header("Input")]
        [SerializeField] private KeyCode interactKey = KeyCode.E;

        [Header("UI")]
        [SerializeField] private InteractionUI interactionUI;

        private IInteractable _current;

        private void Update()
        {
            Detect();
            HandleInput();
        }

        private void Detect()
        {
            IInteractable found = null;

            if (playerCamera != null)
            {
                Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

                if (Physics.Raycast(ray, out RaycastHit hit, range, interactableMask, QueryTriggerInteraction.Ignore))
                {
                    found = hit.collider.GetComponentInParent<IInteractable>();
                }
            }

            if (!ReferenceEquals(_current, found))
            {
                _current = found;

                if (_current != null && _current.CanInteract)
                {
                    interactionUI?.ShowPrompt(_current.PromptText);
                }
                else
                {
                    interactionUI?.HidePrompt();
                    interactionUI?.HideHold();
                }
            }
            else
            {
                // ayný objeye bakýyorsak ama CanInteract deðiþtiyse prompt'u güncelle
                if (_current != null)
                {
                    if (_current.CanInteract)
                        interactionUI?.ShowPrompt(_current.PromptText);
                    else
                        interactionUI?.HidePrompt();
                }
            }
        }

        private void HandleInput()
        {
            if (_current == null) return;
            if (!_current.CanInteract) return;

            if (Input.GetKeyDown(interactKey))
            {
                _current.Interact();
            }
        }
    }
}
