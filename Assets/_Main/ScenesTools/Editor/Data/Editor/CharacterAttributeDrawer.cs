using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(CharacterAttribute))]
public class CharacterAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty nameProp = property.FindPropertyRelative("attributeName");
        SerializedProperty levelProp = property.FindPropertyRelative("level");

        float lineHeight = EditorGUIUtility.singleLineHeight;
        float spacing = EditorGUIUtility.standardVerticalSpacing;

        Rect nameRect = new Rect(position.x, position.y, position.width, lineHeight);
        Rect levelRect = new Rect(position.x, position.y + lineHeight + spacing, position.width, lineHeight);

        EditorGUI.PropertyField(nameRect, nameProp);

        Color defaultColor = GUI.color;
        GUI.color = GetLevelColor(levelProp.intValue);

        levelProp.intValue = EditorGUI.IntSlider(levelRect, "Level", levelProp.intValue, 1, 99);

        GUI.color = defaultColor;

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight * 2 + EditorGUIUtility.standardVerticalSpacing;
    }

    private Color GetLevelColor(int level)
    {
        if (level <= 20) return Color.green;
        else if (level <= 40) return Color.cyan;
        else if (level <= 60) return Color.blue;
        else if (level <= 80) return Color.magenta;
        else return Color.yellow;
    }
}