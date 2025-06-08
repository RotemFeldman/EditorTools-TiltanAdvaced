using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptable", menuName = "Scriptable Objects/Character Scriptable")]
public class CharacterScriptable : ScriptableObject
{
    [Header("Character Info")]
    public string characterName;
    [TextArea]
    public string text;
    public string weaponTypes;
    public string startingSkills;
    public Texture2D sprite;

    [Header("Stats")]
    [Range(1, 99)] public int vitality;
    [Range(1, 99)] public int might;
    [Range(1, 99)] public int agility;
    [Range(1, 99)] public int defense;
    [Range(1, 99)] public int luck;
}