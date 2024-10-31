using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//玩家对象
public class PlayerObj : FightObj
{
    public override void InitObj(params int[] ids)
    {
        base.InitObj(ids);
        //初始化玩家属性
        _property = new PlayerProperty();
        _property.SetData(ids[0],ids[1]);
    }
}
