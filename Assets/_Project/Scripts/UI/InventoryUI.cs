using System.Text;
using Project.Core.Inventory;
using TMPro;
using UnityEngine;

namespace Project.UI
{
    public sealed class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        [SerializeField] private TMP_Text inventoryText;

        private readonly StringBuilder _sb = new StringBuilder(128);

        private void Update()
        {
            if (inventory == null || inventoryText == null) return;

            _sb.Clear();
            _sb.AppendLine("Inventory:");

            foreach (string id in inventory.GetAllItemIds())
            {
                _sb.Append("- ").AppendLine(id);
            }

            inventoryText.text = _sb.ToString();
        }
    }
}
