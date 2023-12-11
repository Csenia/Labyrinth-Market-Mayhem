using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public ItemType ItemType;
    public Sprite Sprite;
}

[CreateAssetMenu]
public class ItemIcons : ScriptableObject
{
    public ItemData[] ItemsDatas;

    public Sprite GetSprite(ItemType itemType)
    {
        for (int i = 0; i < ItemsDatas.Length; i++)
        {
            if (ItemsDatas[i].ItemType == itemType)
            {
                return ItemsDatas[i].Sprite;
            }
        }
        return null;

    }
}

