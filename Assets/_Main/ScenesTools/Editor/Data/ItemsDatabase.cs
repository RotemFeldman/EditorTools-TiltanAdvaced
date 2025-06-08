using UnityEngine;

[CreateAssetMenu(fileName = "ItemsDatabase", menuName = "Scriptable Objects/ItemsDatabase")]
public class ItemsDatabase : ScriptableObject
{
    public ItemsData[] items;
}