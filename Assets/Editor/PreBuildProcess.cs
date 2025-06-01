using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class PreBuildProcess: IPreprocessBuildWithReport
{
    public int callbackOrder => 0;
    public void OnPreprocessBuild(BuildReport report)
    {
        string requieredScene = "Assets/Scenes/MainMenu.unity";
        bool sceneExist = false;

        foreach (var scene in EditorBuildSettings.scenes)
        {
            if (scene.path == requieredScene)
                sceneExist = true;
        }

        if (!sceneExist)
        {
            EditorUtility.DisplayDialog("Error", "Seems you forgot something... the main menu scene not found", "Roger!");
            throw new BuildFailedException("Scene not found in build settings " + requieredScene);
        }
    }
}
