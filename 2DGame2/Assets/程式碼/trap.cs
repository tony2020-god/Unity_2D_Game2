﻿using UnityEngine;

public class trap : MonoBehaviour
{
    /// <summary>
    /// 陷阱
    /// </summary>
    [Header("要觸發的粒子")]
    public ParticleSystem ps;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "玩家")
        {
            ps.Play();
            collision.GetComponent<Player>().Dead("陷阱");
        }
    }
}
