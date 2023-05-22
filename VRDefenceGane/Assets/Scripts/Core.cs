using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Core : MonoBehaviour
{
    public static Core instance;
    
    public int maxHP = 10;
    private int hp;

    public UnityEvent<string> OnHpChanged;
    public UnityEvent OnHit;
    public UnityEvent OnDestroy;

    private void Awake()
    {
        instance = this;
    }

    private void DecreaseHp(int amount)
    {
        if (hp <= 0)
            return;
        hp -= amount;
        if (hp <= 0)
        {
            hp = 0;
            OnDestroy?.Invoke();
        }
    }
    private void UpdateUI()
    {
        OnHpChanged?.Invoke($"HP\n{hp}");
    }

    private void OnEnable()
    {
        hp = maxHP;
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        var mob = other.GetComponent<Mob>();
        if( mob != null )
        {
            OnHit?.Invoke();
            DecreaseHp(1);
            mob.Destroy();
        }
    }
}