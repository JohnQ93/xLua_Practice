﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CSharpCallLua : MonoBehaviour {

    private LuaEnv luaenv;

    void Start () {
        luaenv = new LuaEnv();

        luaenv.DoString("require 'CSharpCallLua'");

        print(luaenv.Global.Get<int>("a"));
        print(luaenv.Global.Get<string>("str"));
        print(luaenv.Global.Get<bool>("isDie"));

        Person p = luaenv.Global.Get<Person>("person"); //通过class来接受 值拷贝
        print(p.Name + "-" + p.age);
        p.eat(2, 5);

        IPerson p2 = luaenv.Global.Get<IPerson>("person"); //通过interface来接受  引用拷贝
        print(p2.Name + "-" + p2.age);
        p2.eat(12, 34);
        p2.add(111, 222);
        p2.Name = "John.q";
        luaenv.DoString("print(person.Name)");

        Dictionary<string, object> dict = luaenv.Global.Get<Dictionary<string, object>>("person");  //Dictionary可以用来接收表中的键值对
        foreach (var key in dict.Keys)
        {
            print(key + "--" + dict[key]);
        }

        List<object> list = luaenv.Global.Get<List<object>>("person");  //List可以用来接收表中的数组，未定义Key的种类
        foreach (object o in list)
        {
            print(o);
        }

        LuaTable tab = luaenv.Global.Get<LuaTable>("person");  //通过LuaTable来访问表中数据，不推荐，速度比较慢
        print(tab.Get<string>("Name"));
        print(tab.Get<int>("age"));

        Mul mul = luaenv.Global.Get<Mul>("multiply");
        int resa = 2; int resb;
        int res = mul(12, 2, ref resa, out resb);
        print(res);
        print(resa);
        print(resb);

        LuaFunction func = luaenv.Global.Get<LuaFunction>("multiply"); //通过LuaFunction来访问全局函数，生成代码量小，访问速度慢
        object[] objs = func.Call(2, 5, 3);
        foreach (var item in objs)
        {
            print(item);
        }
    }
    [CSharpCallLua]
    delegate int Mul(int a, int b, ref int resa, out int resb);  //定义delegate来映射lua中的全局函数，使用out来接受多个返回值

    void OnDestroy () {
        luaenv.Dispose();
    }

    class Person
    {
        public string Name;
        public int age;
        public void eat(int a, int b) {
            print("a+b=" + (a + b));
        }
    }

    [CSharpCallLua]
    interface IPerson
    {
        string Name { get; set; }
        int age { get; set; }
        void eat(int a,int b);
        void add(int a, int b);
    }
}
