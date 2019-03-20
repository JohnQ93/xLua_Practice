using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;
public class CreateCustomLoader : MonoBehaviour {

    private LuaEnv luaenv;
    // Use this for initialization
    void Start () {
        luaenv = new LuaEnv();

        luaenv.AddLoader(MyLoader);

        luaenv.DoString("require 'test007'");
    }

    private byte[] MyLoader(ref string filePath)
    {
        print(filePath);

        string absPath = Application.streamingAssetsPath + "/" + filePath + ".lua.txt";

        return File.ReadAllBytes(absPath);

        //return System.Text.Encoding.UTF8.GetBytes(str);
    }

    void OnDestroy () {
        luaenv.Dispose();
    }
}
