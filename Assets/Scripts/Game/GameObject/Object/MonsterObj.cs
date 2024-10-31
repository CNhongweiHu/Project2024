using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//怪物对象
public class MonsterObj : FightObj
{
    public override void InitObj(params int[] ids)
    {
        base.InitObj(ids);
        //怪物属性初始化
        _property = new MonsterProperty;
        _property.SetData(ids[0]);
    }

}
