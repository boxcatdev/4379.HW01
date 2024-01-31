using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    private bool _canMove = true;
    protected override void Move()
    {
        if (_canMove)
            base.Move();
    }
    protected override void OnHit()
    {
        Debug.Log("Tank Hit");

        _stunProgress = _stunDuration;
        _canMove = false;

        //StartCoroutine(StunForSeconds(1f));
    }

    //coroutine method timer
    IEnumerator StunForSeconds(float duration)
    {
        yield return new WaitForSeconds(duration);

        _canMove = true;
    }


    //update method timer
    private float _stunProgress;
    private float _stunDuration = 1;

    public void Update()
    {
        if (_canMove == false)
        {
            _stunProgress -= Time.deltaTime;
            if (_stunProgress <= 0)
            {
                _canMove = true;
            }
        }
    }

}
