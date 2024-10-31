using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//基础对象
//可能会播放一些模型动画
public class BaseObj : EntityObj
{
    //对象的动画组件
    private Animator _animator;
    ///获取动画的对象组件
    public Animator animator { get => _animator;}

}
