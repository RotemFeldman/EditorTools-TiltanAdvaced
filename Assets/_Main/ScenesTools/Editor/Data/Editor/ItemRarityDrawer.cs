using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ItemRarity))]
public class ItemRarityDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        ItemRarity rarity = (ItemRarity)property.enumValueIndex;
        Color defaultColor = GUI.color;
        GUI.color = GetRarityColor(rarity);
        property.enumValueIndex = EditorGUI.Popup(position, label.text, property.enumValueIndex, property.enumDisplayNames);
        GUI.color = defaultColor;
        EditorGUI.EndProperty();
    }

    private Color GetRarityColor(ItemRarity rarity)
    {
        switch (rarity)
        {
            case ItemRarity.Common:
                return Color.green;
            case ItemRarity.Uncommon:
                return Color.cyan;
            case ItemRarity.Rare:
                return Color.blue;
            case ItemRarity.Epic:
                return Color.magenta;
            case ItemRarity.Legendary:
                return Color.yellow;
            default:
                return Color.gray;
        }
    }
}