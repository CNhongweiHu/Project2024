using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightProperty : BaseObjProperty
{
    //等级
    private int _level;
    //移速
    private int _moveSpeed;
    //攻击速度
    private int _atkSpeed;
    //转身速度
    private int _turnAroundSpeed;

    //当前生命值
    private int _curHP;
    //最大生命值
    private int _maxHP;
    //生命值恢复速度(点/秒)
    private int _hpSpeed;
    //生命值恢复速度（点/次）
    private int _hpHitSpeed;

    //当前能量值
    private int _curMP;
    //最大能量值
    private int _maxMP;
    //能量值恢复速度(点/秒)
    private int _mpSpeed;
    //能量值恢复速度（点/次）
    private int _mpHitSpeed;

    //攻击力
    private int _atk;
    //防御力
    private int _def;
    //命中几率
    private int _fightRate;
    //闪避几率
    private int _missRate;
    //暴击几率
    private int _critRate;
    //抗暴几率
    private int _reCritRate;
    //暴击伤害
    private int _critDamage;
    //暴防伤害
    private int _reCritDamage;
    //格挡几率
    private int _parryRate;

    //BUFF离头顶距离
    private int _buffHeight;
    //倒地时间
    private int _fallTime;

    //强制霸体连击次数
    private int _beComboHitNum;
    //动作特效对应关系
    private Dictionary<string, string> _actionSound = new Dictionary<string, string>();
    //动作特效对应关系
    private Dictionary<string, string> _actionEff = new Dictionary<string, string>();
    
    //调用父类构造函数
    public FightProperty() : base()
    {
        //置零，初始化
        level = 0;
        moveSpeed = 0;
        atkSpeed = 0;
        turnAroundSpeed = 0;
        curHP = 0;
        maxHP = 0;
        hpSpeed = 0;
        hpHitSpeed = 0;
        curMP = 0;
        maxMP = 0;
        mpSpeed = 0;
        mpHitSpeed = 0;
        atk = 0;
        def = 0;
        fightRate = 0;
        missRate = 0;
        critRate = 0;
        reCritRate = 0;
        critDamage = 0;
        reCritDamage = 0;
        parryRate = 0;
        buffHeight = 0;
        fallTime = 0;
        beComboHitNum = 0;
    }
    /// <summary>
    /// 等级读取
    /// </summary>
    public int level { 
        get => EncryptionUtil.UnLockValue(_level,lockKey);
        set => _level = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 移速读取
    /// </summary>
    public int moveSpeed { 
        get => EncryptionUtil.UnLockValue(_moveSpeed,lockKey);
        set => _moveSpeed = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 攻速读取
    /// </summary>
    public int atkSpeed { 
        get => EncryptionUtil.UnLockValue(_atkSpeed,lockKey);
        set => _atkSpeed = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 转身速度读取
    /// </summary>
    public int turnAroundSpeed {
        get => EncryptionUtil.UnLockValue(_turnAroundSpeed,lockKey);
        set => _turnAroundSpeed = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 当前生命值读取
    /// </summary>
    public int curHP {
        get => EncryptionUtil.UnLockValue(_curHP,lockKey);
        set => _curHP = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 生命值上限读取
    /// </summary>
    public int maxHP {
        get => EncryptionUtil.UnLockValue(_maxHP,lockKey);
        set => _maxHP = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 回血速度
    /// </summary>
    public int hpSpeed {
        get => EncryptionUtil.UnLockValue(_hpSpeed,lockKey);
        set => _hpSpeed = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 当次生命值恢复值
    /// </summary>
    public int hpHitSpeed {
        get => EncryptionUtil.UnLockValue(_hpHitSpeed,lockKey);
        set => _hpHitSpeed = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 当前能量值
    /// </summary>
    public int curMP {
        get => EncryptionUtil.UnLockValue(_curMP,lockKey);
        set => _curMP = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 最大能量值
    /// </summary>
    public int maxMP {
        get => EncryptionUtil.UnLockValue(_maxMP,lockKey);
        set => _maxMP = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 能量恢复速度
    /// </summary>
    public int mpSpeed {
        get => EncryptionUtil.UnLockValue(_mpSpeed,lockKey);
        set => _mpSpeed = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 当次能量恢复值
    /// </summary>
    public int mpHitSpeed {
        get => EncryptionUtil.UnLockValue(_mpHitSpeed,lockKey);
        set => _mpHitSpeed = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 攻击力
    /// </summary>
    public int atk {
        get => EncryptionUtil.UnLockValue(_atk,lockKey);
        set => _atk = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 防御力
    /// </summary>
    public int def {
        get => EncryptionUtil.UnLockValue(_def,lockKey);
        set => _def = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 命中率
    /// </summary>
    public int fightRate {
        get => EncryptionUtil.UnLockValue(_fightRate,lockKey);
        set => _fightRate = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 闪避率
    /// </summary>
    public int missRate {
        get => EncryptionUtil.UnLockValue(_missRate,lockKey);
        set => _missRate = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 暴击率
    /// </summary>
    public int critRate {
        get => EncryptionUtil.UnLockValue(_critRate,lockKey);
        set => _critRate = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 暴击抵抗
    /// </summary>
    public int reCritRate {
        get => EncryptionUtil.UnLockValue(_reCritRate,lockKey);
        set => _reCritRate = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 暴击伤害
    /// </summary>
    public int critDamage {
        get => EncryptionUtil.UnLockValue(_critDamage,lockKey);
        set => _critDamage = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 暴击伤害减免
    /// </summary>
    public int reCritDamage {
        get => EncryptionUtil.UnLockValue(_reCritDamage,lockKey);
        set => _reCritDamage = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 格挡几率
    /// </summary>
    public int parryRate {
        get => EncryptionUtil.UnLockValue(_parryRate,lockKey);
        set => _parryRate = EncryptionUtil.LockValue(value,lockKey); }

    /// <summary>
    /// BUFF高度
    /// </summary>
    public int buffHeight {
        get => EncryptionUtil.UnLockValue(_buffHeight,lockKey);
        set => _buffHeight = EncryptionUtil.LockValue(value,lockKey); }
    
    /// <summary>
    /// 倒地时间
    /// </summary>
    public int fallTime {
        get => EncryptionUtil.UnLockValue(_fallTime,lockKey);
        set => _fallTime = EncryptionUtil.LockValue(value,lockKey); }

    /// <summary>
    /// 强制霸体连击次数
    /// </summary>
    public int beComboHitNum {
        get => EncryptionUtil.UnLockValue(_beComboHitNum,lockKey);
        set => _beComboHitNum = EncryptionUtil.LockValue(value,lockKey); }
}