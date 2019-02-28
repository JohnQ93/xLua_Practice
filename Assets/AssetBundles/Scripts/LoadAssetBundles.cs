using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class LoadAssetBundles : MonoBehaviour {


    void Start () {
        string path = "AssetBundles/";
        AssetBundle ab = AssetBundle.LoadFromFile(path + "waterball.unity3d");
        AssetBundle ab2 = AssetBundle.LoadFromFile(path + "watercapsule.unity3d");
        AssetBundle manifestab = AssetBundle.LoadFromFile(path + "AssetBundles");
        AssetBundleManifest manifest = manifestab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        foreach (string name in manifest.GetAllAssetBundles())
        {
            Debug.Log(name);

        }
        foreach (string dep in manifest.GetAllDependencies("waterball.unity3d"))
        {
            Debug.Log(dep);
            AssetBundle.LoadFromFile(path + dep);
        }

        GameObject asset = ab.LoadAsset<GameObject>("Sphere");
        GameObject asset2 = ab2.LoadAsset<GameObject>("Capsule");
        Instantiate(asset);
        Instantiate(asset2);
        //StartCoroutine(LoadAssets());
    }

    IEnumerator LoadAssets()
    {
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle("file:///" + Path.Combine(Application.dataPath, "../") + "/AssetBundles/waterball.unity3d");
        yield return request.SendWebRequest();
        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
        GameObject asset = ab.LoadAsset<GameObject>("Sphere");
        Instantiate(asset);
    }
}
