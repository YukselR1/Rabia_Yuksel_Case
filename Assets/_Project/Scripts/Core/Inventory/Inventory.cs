using System.Collections.Generic;
using UnityEngine;

namespace Project.Core.Inventory
{
    public sealed class Inventory : MonoBehaviour
    {
        private readonly HashSet<string> _itemIds = new HashSet<string>();

        public bool HasItem(ItemData item)
        {
            if (item == null) return false;
            return _itemIds.Contains(item.ItemId);
        }

        public void AddItem(ItemData item)
        {
            if (item == null) return;
            _itemIds.Add(item.ItemId);
        }

        public IEnumerable<string> GetAllItemIds()
        {
            return _itemIds;
        }
    }
}
