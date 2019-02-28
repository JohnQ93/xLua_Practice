using UnityEngine;
using UnityEditor;
using System.IO;

public class BuildAssetBundle {

    [MenuItem("Build AssetBundles/Build Assets")]
    public static void BuildAssetBundles()
    {
        string path = "AssetBundles";
        Directory.Delete(path, true);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
        Application.OpenURL("File:///" + Path.Combine(Application.dataPath, "../" + path));
    }
}
