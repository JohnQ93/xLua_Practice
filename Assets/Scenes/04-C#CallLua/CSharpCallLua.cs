using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CSharpCallLua : MonoBehaviour {

    private LuaEnv luaenv;

    void Start () {
        luaenv = new LuaEnv();

        luaenv.DoString("require 'CSharpCallLua'");

        //print(luaenv.Global.Get<int>("a"));
        //print(luaenv.Global.Get<string>("str"));
        //print(luaenv.Global.Get<bool>("isDie"));

        Person p = luaenv.Global.Get<Person>("person"); //通过class来接受 值拷贝
        print(p.Name + "-" + p.age);
        p.eat(2, 5);

        IPerson p2 = luaenv.Global.Get<IPerson>("person"); //通过interface来接受  引用拷贝
        print(p2.Name + "-" + p2.age);
        p2.eat(12,34);
        p2.add(111, 222);
        p2.Name = "John.q";
        luaenv.DoString("print(person.Name)");
    }

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
