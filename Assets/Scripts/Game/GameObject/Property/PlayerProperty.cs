using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : FightProperty
{
    //当前经验值
    private int _curExp;
    //本等级 最大经验值
    private int _maxExp;
    //职业ID
    private int _professionID;
    //主动技能ID
    private List<int> _skillIDs = new List<int>();
    //被动技能ID
    private List<int> _passiveSkillIDs = new List<int>();

    public PlayerProperty():base()
    {
        curExp = 0;
        maxExp = 0;
        _professionID = 0;
    }
    /// <summary>
    /// 初始化属性信息的方法
    /// </summary>
    /// <param name="professionID"></param>
    /// <param name="level"></param>
    public void SetData(int professionID, int level)
    {
        //得到角色配置表当中对应的数据 用于初始化角色属性
        T_Player playerInfo = BinaryDataMgr.Instance.GetTable<T_PlayerContainer>().dataDic[professionID + "-" + level]
    }
    /// <summary>
    /// 当前经验值
    /// </summary>
    public int curExp { 
        get => EncryptionUtil.UnLockValue(_curExp, lockKey);
        set => _curExp = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// 本等级 最大经验值
    /// </summary>
    public int maxExp { 
        get => EncryptionUtil.UnLockValue(_maxExp, lockKey);
        set => _maxExp = EncryptionUtil.LockValue(value, lockKey);}
    /// <summary>
    /// 职业ID
    /// </summary>
    public int professionID { 
        get => EncryptionUtil.UnLockValue(_professionID, lockKey);
        set => _professionID = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// 主动技能ID
    /// </summary>
    public List<int> skillIDs {
        get => _skillIDs;
        set => _skillIDs = value; }
    /// <summary>
    /// 被动技能ID
    /// </summary>
    public List<int> passiveSkillIDs {
        get => _passiveSkillIDs;
        set => _passiveSkillIDs = value; }
}
