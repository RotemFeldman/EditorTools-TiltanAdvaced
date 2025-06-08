using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemsDatabase))]
public class ItemsDatabaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Find all items in assets!"))
        {
            UpdateItemsDatabase();
        }
    }

    private void UpdateItemsDatabase()
    {
        ItemsDatabase itemsDatabase = (ItemsDatabase)target;
        string[] guids = AssetDatabase.FindAssets("t:ItemsData");
        List<ItemsData> itemsDataList = new List<ItemsData>();

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ItemsData itemsData = AssetDatabase.LoadAssetAtPath<ItemsData>(path);
            if (itemsData)
            {
                itemsDataList.Add(itemsData);
            }
        }
        
        itemsDatabase.items = itemsDataList.ToArray();
        EditorUtility.SetDirty(itemsDatabase);
    }
}