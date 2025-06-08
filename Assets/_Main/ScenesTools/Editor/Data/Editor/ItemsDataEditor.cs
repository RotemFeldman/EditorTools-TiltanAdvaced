using UnityEditor;
using UnityEngine;

public class ItemDataEditor : Editor
{
    SerializedProperty itemIcon;
    SerializedProperty itemRarity;
    SerializedProperty upgradeLevel;

    private void OnEnable()
    {
        itemIcon = serializedObject.FindProperty("itemIcon");
        itemRarity = serializedObject.FindProperty("rarity");
        upgradeLevel = serializedObject.FindProperty("upgradeLevel");
    }
    
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUILayout.Label("Item Data Editor", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(itemIcon);
        EditorGUILayout.PropertyField(itemRarity);
        
        Color defaultColor = GUI.color;
        GUI.color = GetRarityColor((ItemRarity)itemRarity.enumValueIndex);
        EditorGUILayout.PropertyField(itemRarity);
        GUI.color = defaultColor;

        EditorGUILayout.IntSlider(upgradeLevel, 0, 10, new GUIContent("Upgrade Level"));
        
        serializedObject.ApplyModifiedProperties();
        
        GUIStyle boxStyle = new GUIStyle(GUI.skin.box)
        {
            border = new RectOffset(50, 50, 50, 50), 
            normal = { background = Texture2D.whiteTexture }
        };
   
        if (itemIcon.objectReferenceValue)
        {
            GUI.backgroundColor = GetRarityColor((ItemRarity)itemRarity.enumValueIndex);
            Texture2D itemIconTexture2D = (itemIcon.objectReferenceValue as Sprite).texture;
            GUILayout.Box(itemIconTexture2D, boxStyle, GUILayout.Width(256), GUILayout.Height(256));
            GUI.backgroundColor = Color.white;
        }
        
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