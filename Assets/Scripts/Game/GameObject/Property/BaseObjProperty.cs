using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 基础对象属性
/// </summary>
public class BaseObjProperty : EntityProperty
{
    //对象的名字
    private string _name;
    //对象对应的图标资源
    private string _iconName;
    /// <summary>
    /// 对象的名字
    /// </summary>
    public string name { get => _name; set => _name = value; }
    /// <summary>
    /// 对象的图标
    /// </summary>
    public string iconName { get => _iconName; set => _iconName = value; }
}
