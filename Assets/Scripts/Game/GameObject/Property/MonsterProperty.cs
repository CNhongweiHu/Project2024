using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterProperty : FightProperty
{
    //缩放比例
    private int _scaleSize;
    //AI id
    private int _aiID;
    //攻击扇形角度
    private int _checkAtkAngle;
    //是否是巡逻怪
    private bool _isPatrol;
    //是否是静止怪
    private bool _isStatic;
    //怪物类型
    private int _monsterType;
    //箱子血量
    private int _boxHP;
    //怪物受击效果
    private int _hitEff;
    //怪物提供经验
    private int _exp;

    //是否受敌方单位力的作用
    private bool _isAtkForce;
    //免疫敌方单位buffID
    private List<int> _immuneBuffIDS = new List<int>();
    //怪物掉落ID
    private int _dropID;
    //死亡起飞概率
    private int _deadFlyChance = 0;
    //死亡起飞水平速度
    private int _deadSpeedH = 0;
    //死亡起飞垂直速度
    private int _deadSpeedV = 0;

    //怪物技能相关 - 技能1
    private int _skill1;
    //怪物技能相关 - 技能2
    private int _skill2;
    //怪物技能相关 - 技能3
    private int _skill3;
    //怪物技能相关 - 技能4
    private int _skill4;
    //怪物技能相关 - 技能5
    private int _skill5;

    public MonsterProperty():base()
    {
        scaleSize = 10000;
        aiID = 0;
        checkAtkAngle = 0;
        isStatic = false;
        isPatrol = false;
        monsterType = 1;
        boxHP = 0;
        hitEff = 0;
        exp = 0;
        isAtkForce = true;
        dropID = 0;
        deadFlyChance = 0;
        deadSpeedH = 0;
        deadSpeedV = 0;
        skill1 = 0;
        skill2 = 0;
        skill3 = 0;
        skill4 = 0;
        skill5 = 0;
    }

    public override void SetData(int id)
    {
        //得到怪物配置表中的数据
        T_Monster monsterInfo = BinaryDataMgr.Instance.GetTable<T_MonsterContainer>().dataDic[id];
        this.tableID = id;
        this.name = monsterInfo.f_name;
        this.iconName = monsterInfo.f_icon;
        this.resName = monsterInfo.f_model;
        this.scaleSize = monsterInfo.f_scale;
        this.level = monsterInfo.f_level;
        this.aiID = monsterInfo.f_ai;
        this.checkAtkAngle = monsterInfo.f_atkEnemy_radius;

        this.isStatic = monsterInfo.f_move_type == 1;
        this.isPatrol = monsterInfo.f_patrol_type == 1;

        this.monsterType = monsterInfo.f_type;
        this.boxHP = monsterInfo.f_box_hp;
        this.hitEff = monsterInfo.f_strike_lv;
        this.exp = monsterInfo.f_kill_exp;
        this.isAtkForce = monsterInfo.f_attack_haveStrike == 0;

        this.immuneBuffIDS = new List<int>(TextUtil.SplitStrToIntArr(monsterInfo.f_immune_buff_kind, 2));
        this.dropID = monsterInfo.f_drop;
        int[] ints = TextUtil.SplitStrToIntArr(monsterInfo.f_death, 2);
        this.deadFlyChance = ints[0];
        this.deadSpeedH = ints[1];
        this.deadSpeedV = ints[2];

        this.skill1 = monsterInfo.f_monster_skill0;
        this.skill2 = monsterInfo.f_monster_skill1;
        this.skill3 = monsterInfo.f_monster_skill2;
        this.skill4 = monsterInfo.f_monster_skill3;
        this.skill5 = monsterInfo.f_monster_skill4;

        this.turnAroundSpeed = monsterInfo.f_turn_speed;
        this.atkSpeed = monsterInfo.f_atk_speed;
        this.moveSpeed = monsterInfo.f_move_speed;

        this.curHP = this.maxHP = monsterInfo.f_hp;

        this.curMP = this.maxMP = monsterInfo.f_mp;
        this.mpSpeed = monsterInfo.f_magic_speed;
        this.mpHitSpeed = monsterInfo.f_magic_atk;

        this.atk = monsterInfo.f_atk;
        this.def = monsterInfo.f_defense;
        this.fightRate = monsterInfo.f_hit;
        this.missRate = monsterInfo.f_dodge;
        this.critRate = monsterInfo.f_crit;
        this.reCritRate = monsterInfo.f_crit_re;
        this.critDamage = monsterInfo.f_crit_damage;
        this.reCritDamage = monsterInfo.f_crit_re_damage;
        this.parryRate = monsterInfo.f_block;

        this.fallTime = monsterInfo.f_down_time;
        this.buffHeight = monsterInfo.f_buff_h;

        this.beComboHitNum = monsterInfo.f_monster_pabody_condition;

        TextUtil.SplitStrTwice(monsterInfo.f_action_sound, 1, 2, (actionName, soundName) =>
        {
            this.actionSound.Add(actionName, soundName);
        });

        TextUtil.SplitStrTwice(monsterInfo.f_action_effect, 1, 2, (actionName, effName) =>
        {
            this.actionEff.Add(actionName, effName);
        });

    }

    /// <summary>
    /// 缩放比例
    /// </summary>
    public int scaleSize { get => EncryptionUtil.UnLockValue(_scaleSize, lockKey); set => _scaleSize = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// AI ID
    /// </summary>
    public int aiID { get => EncryptionUtil.UnLockValue(_aiID, lockKey); set => _aiID = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// 攻击扇形角度
    /// </summary>
    public int checkAtkAngle { get => EncryptionUtil.UnLockValue(_checkAtkAngle, lockKey); set => _checkAtkAngle = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// 是否是静止怪
    /// </summary>
    public bool isStatic { get => _isStatic; set => _isStatic = value; }
    /// <summary>
    /// 是否是巡逻怪
    /// </summary>
    public bool isPatrol { get => _isPatrol; set => _isPatrol = value; }
    /// <summary>
    /// 怪物类型
    /// </summary>
    public int monsterType { get => EncryptionUtil.UnLockValue(_monsterType, lockKey); set => _monsterType = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// 怪物受击效果
    /// </summary>
    public int hitEff { get => EncryptionUtil.UnLockValue(_hitEff, lockKey); set => _hitEff = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// 怪物提供经验
    /// </summary>
    public int exp { get => EncryptionUtil.UnLockValue(_exp, lockKey); set => _exp = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// 是否受地方单位力的作用
    /// </summary>
    public bool isAtkForce { get => _isAtkForce; set => _isAtkForce = value; }
    /// <summary>
    /// 免疫敌方单位的BuffID
    /// </summary>
    public List<int> immuneBuffIDS { get => _immuneBuffIDS; set => _immuneBuffIDS = value; }
    /// <summary>
    /// 怪物掉落ID
    /// </summary>
    public int dropID { get => EncryptionUtil.UnLockValue(_dropID, lockKey); set => _dropID = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// 死亡起飞概率
    /// </summary>
    public int deadFlyChance { get => EncryptionUtil.UnLockValue(_deadFlyChance, lockKey); set => _deadFlyChance = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// 死亡起飞水平速度
    /// </summary>
    public int deadSpeedH { get => EncryptionUtil.UnLockValue(_deadSpeedH, lockKey); set => _deadSpeedH = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// 死亡起飞垂直速度
    /// </summary>
    public int deadSpeedV { get => EncryptionUtil.UnLockValue(_deadSpeedV, lockKey); set => _deadSpeedV = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// 技能1
    /// </summary>
    public int skill1 { get => EncryptionUtil.UnLockValue(_skill1, lockKey); set => _skill1 = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// 技能2
    /// </summary>
    public int skill2 { get => EncryptionUtil.UnLockValue(_skill2, lockKey); set => _skill2 = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// 技能3
    /// </summary>
    public int skill3 { get => EncryptionUtil.UnLockValue(_skill3, lockKey); set => _skill3 = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// 技能4
    /// </summary>
    public int skill4 { get => EncryptionUtil.UnLockValue(_skill4, lockKey); set => _skill4 = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// 技能5
    /// </summary>
    public int skill5 { get => EncryptionUtil.UnLockValue(_skill5, lockKey); set => _skill5 = EncryptionUtil.LockValue(value, lockKey); }
    /// <summary>
    /// 箱子血量
    /// </summary>
    public int boxHP { get => EncryptionUtil.UnLockValue(_boxHP, lockKey); set => _boxHP = EncryptionUtil.LockValue(value, lockKey); }

}