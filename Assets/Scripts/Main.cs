using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //初始化读取配置表数据
        BinaryDataMgr.Instance.InitData();
/*         
        //取出玩家表中的指定Key的一行数据
        T_Player PlayerTestInfo = BinaryDataMgr.Instance.GetTable<T_PlayerContainer>().dataDic["1_1"];
        //取出怪物表中的指定Key的一行数据
        T_Monster MonsterTestInfo = BinaryDataMgr.Instance.GetTable<T_MonsterContainer>().dataDic[1004];
        print(PlayerTestInfo.f_icon);
        print(MonsterTestInfo.f_des); */

        //测试玩家属性能不能传入对应值
        PlayerProperty playerProperty = new PlayerProperty();
        playerProperty.SetData(1,1);
        print(playerProperty.name);
        foreach(var key in playerProperty.actionEff.Keys)
        {
            print(key + "_" + playerProperty.actionEff[key]);
        }

        MonsterProperty monsterProperty = new MonsterProperty();
        monsterProperty.SetData(1004);
        print(monsterProperty.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
