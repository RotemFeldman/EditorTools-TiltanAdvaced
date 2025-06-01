using System;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;


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

    [MenuItem("Tools/Clear Scene")]
    public static void ClearScene()
    {
        bool confirmClearing = EditorUtility.DisplayDialog("Delete All Scene?!","You are about to delete ALL GameObjects in current scene! Are you sure you want to continue?", "Due It", "Noooooo!");

        if (!confirmClearing)
        {
            return;
        }
        
        GameObject[] allObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        Undo.RegisterCompleteObjectUndo(allObjects, "Clear Scene");

        int deleted = 0;

        foreach (GameObject obj in allObjects)
        {
            if (obj.CompareTag("MainCamera") || obj.CompareTag("Light"))
                continue;
            
            Undo.DestroyObjectImmediate(obj);
            deleted++;
        }
        
        bool undo = EditorUtility.DisplayDialog("Success", $"Scene has been cleared! (total {deleted} objects)","Undo", "OK");

        if (undo)
        {
            Undo.PerformUndo();
        }
    }
}
