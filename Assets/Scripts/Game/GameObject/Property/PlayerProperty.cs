using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    /// <param name="ids"></param>
    /// 需要传递两个int，第一个代表职业，第二个代表等级
    public override void SetData(params int[] ids)//玩家对象属性初始化方法
    {
        //得到角色配置表当中对应的数据 用于初始化角色属性
        T_Player playerInfo = BinaryDataMgr.Instance.GetTable<T_PlayerContainer>().dataDic[professionID + "_" + level];

        this.professionID = ids[0];
        //等级
        this.level = ids[1];
        //名称
        this.name = playerInfo.f_name;
        this.iconName = playerInfo.f_icon;
        //经验
        this.maxExp = playerInfo.f_exp;
        //资源
        this.resName = playerInfo.f_model;
        //转身和移动
        this.turnAroundSpeed = playerInfo.f_turn_speed;
        this.moveSpeed = playerInfo.f_move_speed;
        //血量相关
        this.curHP = this.maxHP = playerInfo.f_hp;
        this.hpHitSpeed = playerInfo.f_hp_atk;
        this.hpSpeed = playerInfo.f_hp_speed;
        //能量值相关
        this.curMP = this.maxMP = playerInfo.f_mp;
        this.mpHitSpeed = playerInfo.f_magic_atk;
        this.mpSpeed = playerInfo.f_magic_speed;
        //攻击力和攻速
        this.atkSpeed = playerInfo.f_atk_speed;
        this.atk = playerInfo.f_atk;
        this.def = playerInfo.f_defense;
        //命中率和闪避率
        this.fightRate = playerInfo.f_hit;
        this.missRate = playerInfo.f_dodge;
        this.critRate = playerInfo.f_crit;
        this.reCritDamage = playerInfo.f_crit_re;
        this.critDamage = playerInfo.f_crit_damage;
        this.reCritDamage = playerInfo.f_crit_re_damage;
        this.parryRate = playerInfo.f_block;

        this.fallTime = playerInfo.f_down_time;
        this.buffHeight = playerInfo.f_buff_h;

        this.beComboHitNum = playerInfo.f_actor_pabody_condition;

        //这里用了小框架内容，可以回头看一下小框架相关，键值类字符串获取
        TextUtil.SplitStrTwice(playerInfo.f_action_sound, 1, 2,(actionName, soundName) =>
        {
            this.actionSound.Add(actionName, soundName);
        });
        TextUtil.SplitStrTwice(playerInfo.f_action_effect, 1, 2,(actionName, effName) =>
        {
            this.actionEff.Add(actionName, effName);
        });
        //主被动技能ID字段获取
        skillIDs = new List<int>(TextUtil.SplitStrToIntArr(playerInfo.f_skill,2));
        passiveSkillIDs = new List<int>(TextUtil.SplitStrToIntArr(playerInfo.f_passiveskill,2));
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
