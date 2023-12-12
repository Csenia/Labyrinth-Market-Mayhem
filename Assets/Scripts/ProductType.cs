using System.Collections;
using UnityEngine;

public enum ItemType
{
    None,
    Apple,
    Orange,
    Banana, 
    Avocado
}

public class ProductType : MonoBehaviour
{
    public ItemType itemType;
}