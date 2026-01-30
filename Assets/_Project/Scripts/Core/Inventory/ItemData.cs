using UnityEngine;

namespace Project.Core.Inventory
{
    [CreateAssetMenu(menuName = "Project/Inventory/Item Data", fileName = "ItemData_")]
    public sealed class ItemData : ScriptableObject
    {
        [SerializeField] private string itemId;   
        [SerializeField] private string displayName;

        public string ItemId => itemId;
        public string DisplayName => displayName;
    }
}
