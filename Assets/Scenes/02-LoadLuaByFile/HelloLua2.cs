using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class HelloLua2 : MonoBehaviour {

    private LuaEnv luaenv;
    // Use this for initialization
    void Start () {
        luaenv = new LuaEnv();

        luaenv.DoString("require 'byfile'");
    }

    // Update is called once per frame
    void Update () {
        if (luaenv != null)
        {
            luaenv.Tick();
        }
    }

    private void OnDestroy()
    {
        luaenv.Dispose();
    }
}
