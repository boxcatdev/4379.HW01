using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : EnemyBase
{
    protected override void OnHit()
    {
        Debug.Log("Charger Hit");
        MoveSpeed *= 2f;
    }
}
