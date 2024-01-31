using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : EnemyBase
{
    [Header("Charger Properties")]
    [SerializeField] private Transform _powerupPrefab;
    protected override void OnHit()
    {
        Debug.Log("Charger Hit");
        MoveSpeed *= 2f;
    }
    public override void Kill()
    {
        Transform powerup = Instantiate(_powerupPrefab, null);
        powerup.position = transform.position;

        base.Kill();
    }
}
