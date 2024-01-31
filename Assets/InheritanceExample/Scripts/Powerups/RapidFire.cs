using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : PowerupBase
{
    private TurretController _turretController;

    private void Awake()
    {
        _turretController = FindObjectOfType<TurretController>();
    }
    protected override void PowerDown()
    {
        Debug.Log("Powerdown Override");

        _turretController.FireCooldown *= 2f;
    }

    protected override void PowerUp()
    {
        Debug.Log("Powerup Override");

        _turretController.FireCooldown *= 0.5f;
    }
    protected override void OnHit()
    {
        base.OnHit();
    }
}
