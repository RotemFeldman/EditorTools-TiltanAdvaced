using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterScriptable))]
public class CharacterEditor : Editor
{
    public const string characterSpritesAssetsPath = "Assets/Sprites/Characters/";
    public SerializedProperty textProperty;
    public SerializedProperty weaponTypesProperty;
    public SerializedProperty startingSkillsProperty;
    public SerializedProperty characterNameProperty;
    private SerializedProperty vitalityProperty;
    private SerializedProperty mightProperty;
    private SerializedProperty agilityProperty;
    private SerializedProperty defenseProperty;
    private SerializedProperty luckProperty;
    
    Texture2D characterTexture;
    
    private void OnEnable()
    {
        textProperty = serializedObject.FindProperty("text");
        weaponTypesProperty = serializedObject.FindProperty("weaponTypes");
        startingSkillsProperty = serializedObject.FindProperty("startingSkills");
        characterNameProperty = serializedObject.FindProperty("characterName");
        vitalityProperty = serializedObject.FindProperty("vitality");
        mightProperty = serializedObject.FindProperty("might");
        agilityProperty = serializedObject.FindProperty("agility");
        defenseProperty = serializedObject.FindProperty("defense");
        luckProperty = serializedObject.FindProperty("luck");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(characterNameProperty);
        characterTexture = GetCharacterSpriteByName(characterNameProperty.stringValue);
        
        if (characterTexture)
        {
            GUILayout.Box(characterTexture, GUILayout.Width(128), GUILayout.Height(128));
        }
        else
        {
            EditorGUILayout.HelpBox("No such character found", MessageType.Error);
        }

        EditorGUILayout.PropertyField(textProperty);
        EditorGUILayout.PropertyField(weaponTypesProperty);
        EditorGUILayout.PropertyField(startingSkillsProperty);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Character Stats", EditorStyles.boldLabel);
        EditorGUILayout.IntSlider(vitalityProperty, 1, 99, new GUIContent("Vitality"));
        EditorGUILayout.IntSlider(mightProperty, 1, 99, new GUIContent("Might"));
        EditorGUILayout.IntSlider(agilityProperty, 1, 99, new GUIContent("Agility"));
        EditorGUILayout.IntSlider(defenseProperty, 1, 99, new GUIContent("Defense"));
        EditorGUILayout.IntSlider(luckProperty, 1, 99, new GUIContent("Luck"));
        serializedObject.ApplyModifiedProperties();
    }

    public Texture2D GetCharacterSpriteByName(string name)
    {
        Texture2D characterTexture2D = AssetDatabase.LoadAssetAtPath<Texture2D>(characterSpritesAssetsPath + name + ".png");
        return characterTexture2D;
    }
}