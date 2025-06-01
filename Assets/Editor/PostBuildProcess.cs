using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System.IO;
using UnityEngine;

public class PostBuildProcess : IPostprocessBuildWithReport
{
    private const string VersionKey = "AutoVersion";
    public int callbackOrder => 0;
    public void OnPostprocessBuild(BuildReport report)
    {
        string outputPath = report.summary.outputPath;
        string directory = Path.GetDirectoryName(outputPath);
        string extension = Path.GetExtension(outputPath);
        string baseName = "EditorTools";
        string currentVersion = EditorPrefs.GetString(VersionKey, "0.01");
        string newFileName = $"{baseName}_v{currentVersion}.{extension}";
        string newFilePath = Path.Combine(directory, newFileName);

        File.Move(outputPath, newFilePath);

        string nextVersion = IncrementVersion(currentVersion);
        EditorPrefs.SetString(VersionKey, nextVersion);
    }
    private string IncrementVersion(string version)
    {
        if (float.TryParse(version, out float v))
        {
            v += 0.01f;
            return v.ToString("0.00");
        }
        return "0.01";
    }
}
