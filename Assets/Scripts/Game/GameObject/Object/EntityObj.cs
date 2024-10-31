using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//实体对象类
//不会有动画，不会有战斗，不会移动的静态物体
public class EntityObj : MonoBehaviour
{
    //对象属性相关
    protected EntityProperty _property;

    //父对象的Transform，资源依附的武器
    private Transform _rootTransfrom;
    //身体的Transform，资源对象的Transform
    private Transform _bodyTransform;
    //保护类型的虚函数
    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    //用于初始化对象属性的方法 在其中进行对象以及属性相关的初始化，是变长参数，根据表的主键决定传几个
    public virtual void InitObj(params int[] ids)
    {

    }
    //获取属性对象的方法
    public virtual T GetProperty<T>() where T:EntityProperty
    {
        return _property as T;
    }
}
