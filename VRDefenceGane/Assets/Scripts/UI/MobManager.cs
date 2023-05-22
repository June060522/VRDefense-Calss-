using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class MobManager : MonoBehaviour
{
    public static MobManager instance;

    private void Awake()
    {
        instance = this;
    }

    public UnityEvent<Mob> OnSpawn, OnDestroy;
    private List<Mob> mobs = new List<Mob>();
    
    public void OnSapwned(Mob mob)
    {
        mobs.Add(mob);
        OnSpawn?.Invoke(mob);
    }
    public void OnDestroyed(Mob mob)
    {
        if(mobs.Remove(mob))
        {
            OnDestroy?.Invoke(mob);
        }
    }

    public void DestroyAll()
    {
        
    }
}
