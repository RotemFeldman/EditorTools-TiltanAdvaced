using UnityEditor;
using UnityEngine;

public class ItemsEditorWindow : EditorWindow
{
    private ItemsDatabase itemsDatabase;
    private string searchQuery = "";
    private Vector2 scrollPosition;

    [MenuItem("Tools/Items Editor")] 
    public static void ShowWindow()
    {
        var window = GetWindow<ItemsEditorWindow>();
        window.titleContent = new GUIContent("Items Editor");
        window.minSize = new Vector2(500, 500);
    }

    private void OnGUI()
    {
        FindItemsDatabase();

        if (!itemsDatabase)
        {
            EditorGUILayout.HelpBox("No ItemsDatabase found...", MessageType.Error);
            return;
        }

        EditorGUILayout.LabelField("Items Database", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Database", itemsDatabase.name);

        if (GUILayout.Button("Select Database in Project"))
        {
            Selection.activeObject = itemsDatabase;
            EditorGUIUtility.PingObject(itemsDatabase);
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Search Items", EditorStyles.boldLabel);

        searchQuery = EditorGUILayout.TextField("Item Name", searchQuery);

        EditorGUILayout.Space();
        PopulateSearchResults();
    }

    private void PopulateSearchResults()
    {
        EditorGUILayout.LabelField("Search Results", EditorStyles.boldLabel);

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        foreach (var item in itemsDatabase.items)
        {
            if (item && item.name.ToLower().Contains(searchQuery.ToLower()))
            {
                EditorGUILayout.BeginHorizontal();

                if (item.itemIcon)
                {
                    GUILayout.Label(item.itemIcon.texture, GUILayout.Width(40), GUILayout.Height(40));
                }

                GUILayout.Label(item.name);

                if (GUILayout.Button("Select", GUILayout.Width(60)))
                {
                    Selection.activeObject = item;
                    EditorGUIUtility.PingObject(item);
                }

                EditorGUILayout.EndHorizontal();
            }
        }
        
        EditorGUILayout.EndScrollView();
    }

    private void FindItemsDatabase()
    {
        if (!itemsDatabase)
        {
            string[] guids = AssetDatabase.FindAssets("t:ItemsDatabase");
            if (guids.Length > 0)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[0]);
                itemsDatabase = AssetDatabase.LoadAssetAtPath<ItemsDatabase>(path);
            }
        }
    }
}