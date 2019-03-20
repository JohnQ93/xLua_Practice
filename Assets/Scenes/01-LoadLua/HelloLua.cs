using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class HelloLua : MonoBehaviour {

    private LuaEnv luaenv;

    void Start () {
        luaenv = new LuaEnv();

        luaenv.DoString("print('Hello Lua!')");

        luaenv.DoString("CS.UnityEngine.Debug.Log('Hello Qiucheng')");
    }

    private void OnDestroy()
    {
        luaenv.Dispose();
    }
}
