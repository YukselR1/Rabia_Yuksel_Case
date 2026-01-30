namespace Project.Core.Interaction
{
    public interface IInteractable
    {
        string PromptText { get; }
        bool CanInteract { get; }

        InteractionType Type { get; }

        // Instant/Toggle için
        void Interact();

        // Hold için
        float HoldDuration { get; }      // saniye
        void OnHoldStart();
        void OnHoldComplete();
        void OnHoldCancel();
    }
}
