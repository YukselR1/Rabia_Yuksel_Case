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

        private bool _isHolding;
        private float _holdTimer;

        private void Update()
        {
            Detect();
            HandleInput();
            UpdateHold();
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
                CancelHoldIfNeeded();

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
                // ayný hedef, prompt güncel kalsýn
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

            switch (_current.Type)
            {
                case InteractionType.Instant:
                case InteractionType.Toggle:
                    if (Input.GetKeyDown(interactKey))
                    {
                        _current.Interact();
                    }
                    break;

                case InteractionType.Hold:
                    if (Input.GetKeyDown(interactKey))
                    {
                        StartHold();
                    }

                    if (Input.GetKeyUp(interactKey))
                    {
                        CancelHoldIfNeeded();
                    }
                    break;
            }
        }

        private void StartHold()
        {
            if (_isHolding) return;

            _isHolding = true;
            _holdTimer = 0f;

            _current.OnHoldStart();
            interactionUI?.ShowHoldProgress(0f);
        }

        private void UpdateHold()
        {
            if (!_isHolding) return;
            if (_current == null) { CancelHoldIfNeeded(); return; }

            float duration = Mathf.Max(0.01f, _current.HoldDuration);
            _holdTimer += Time.deltaTime;

            float normalized = Mathf.Clamp01(_holdTimer / duration);
            interactionUI?.ShowHoldProgress(normalized);

            if (_holdTimer >= duration)
            {
                _isHolding = false;
                interactionUI?.HideHold();

                _current.OnHoldComplete();
            }
        }

        private void CancelHoldIfNeeded()
        {
            if (!_isHolding) return;

            _isHolding = false;
            _holdTimer = 0f;

            interactionUI?.HideHold();
            _current?.OnHoldCancel();
        }
    }
}
