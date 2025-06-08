using UnityEngine;

[CreateAssetMenu(fileName = "CharacterAttribute", menuName = "Scriptable Objects/Character Attribute")]
public class CharacterAttribute : ScriptableObject
{
    public string attributeName;

    [Range(1, 99)]
    public int level;
}