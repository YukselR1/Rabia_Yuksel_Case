using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    public sealed class InteractionUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Text promptText;
        [SerializeField] private Slider holdSlider;

        private void Awake()
        {
            SetPromptVisible(false);
            SetHoldVisible(false);
        }

        public void ShowPrompt(string message)
        {
            if (promptText == null) return;
            promptText.text = message;
            SetPromptVisible(true);
        }

        public void HidePrompt()
        {
            SetPromptVisible(false);
        }

        public void ShowHoldProgress(float normalized)
        {
            if (holdSlider == null) return;
            SetHoldVisible(true);
            holdSlider.value = Mathf.Clamp01(normalized);
        }

        public void HideHold()
        {
            if (holdSlider == null) return;
            holdSlider.value = 0f;
            SetHoldVisible(false);
        }

        private void SetPromptVisible(bool visible)
        {
            if (promptText != null)
                promptText.gameObject.SetActive(visible);
        }

        private void SetHoldVisible(bool visible)
        {
            if (holdSlider != null)
                holdSlider.gameObject.SetActive(visible);
        }
    }
}
