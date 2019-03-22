using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaCallCSharp : MonoBehaviour {

    private LuaEnv luaenv;
    void Start () {
        luaenv = new LuaEnv();

        luaenv.DoString("require 'LuaCallCSharp'");
    }

    void OnDestroy () {
        luaenv.Dispose();
    }
}
