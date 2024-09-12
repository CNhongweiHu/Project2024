using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//实体属性类
//主要表示 场景上出现的对象就会有的属性
public class EntityProperty
{
    private long _uID;
    //唯一ID
    private int _tableID;
    //数据表ID
    private string _resName;
    //资源名

    private int _lockKey;
    //密钥key
    public EntityProperty()
    {
        //构造函数中，对密钥进行随机
        _lockKey = EncryptionUtil.GetRandomKey();
    }
    /// <summary>
    /// 初始化数据
    /// </summary>
    /// <param name="id">传入的模板ID，子函数，提供给子类重写的</param>
    public virtual void SetData(int id){}
    //初始化
    /// <summary>
    /// 唯一ID
    /// </summary>
    public long uID { get => _uID; set => _uID = value; }
    /// <summary>
    /// 数据表ID
    /// </summary>
    public int tableID { 
        get => EncryptionUtil.UnLoackValue(_tableID,_lockKey); 
        set => _tableID = EncryptionUtil.LockValue(value,_lockKey); }
    /// <summary>
    /// 模型资源名
    /// </summary>
    public string resName { get => _resName; set => _resName = value; }
    public int lockKey { get => _lockKey; set => _lockKey = value; }
}