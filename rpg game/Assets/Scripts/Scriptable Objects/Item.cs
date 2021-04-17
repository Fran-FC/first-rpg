using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName="Item")]
public class Item : ScriptableObject
{
    public string objectName;
    public Sprite sprite;
    public int quanity;
    public bool stackable;
    public enum ItemType {
        COIN,
        HEALTH
    };
    public ItemType itemType;
}
