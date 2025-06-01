using System;
using UnityEditor;
using UnityEngine;
using System.Reflection;


public class EditorTools
{
    [MenuItem("Tools/Change Visibility %#o")]
    public static void ChangeVisibility()
    {
        if (Selection.activeGameObject != null)
        {
            GameObject go = Selection.activeGameObject;
            Undo.RecordObject(go, "Change Visibility");
            go.SetActive(!go.activeSelf);
        }
    }

    [MenuItem("Tools/Clear Console %#x")]
    public static void ClearConsole()
    {
        var logEntries = Type.GetType("UnityEditor.LogEntries,UnityEditor.dll");
        if (logEntries != null)
        {
            var clearMethod = logEntries.GetMethod("Clear");
            clearMethod?.Invoke(null, null);
        }
    }
}
