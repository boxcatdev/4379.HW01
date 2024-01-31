using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PowerupBase : MonoBehaviour
{
    [Header("FX")]
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] protected float PowerupDuration = 2f;

    public MeshRenderer _renderer;
    public Collider _collider;

    private float _durationProgress = 1f;
    private bool _isPoweredUp = false;
    private void Awake()
    {
        //_renderer = GetComponentInChildren<MeshRenderer>();
        //_collider = GetComponent<Collider>();
    }
    private void Update()
    {
        /*if(_durationProgress > 0)
        {
            _durationProgress -= Time.deltaTime;
        }
        if(_durationProgress <= 0)
        {
            Debug.Log("PowerDown()");
            PowerDown();

            //disable gameobject
            gameObject.SetActive(false);
        }*/

        if (_isPoweredUp)
        {
            _durationProgress -= Time.deltaTime;
            if(_durationProgress <= 0)
            {
                _isPoweredUp = false;

                Debug.Log("PowerDown()");
                PowerDown();

                //disable gameobject
                gameObject.SetActive(false);

            }
        }
    }

    protected virtual void OnHit()
    {
        //trigger powerup
        _renderer.enabled = false;
        _collider.enabled = false;
        _isPoweredUp = true;
        _durationProgress = PowerupDuration;

        Debug.Log("PowerUp()");
        PowerUp();
    }
    protected abstract void PowerUp();
    protected abstract void PowerDown();

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            AudioHelper.PlayClip2D(_hitSound, 1, .1f);
            OnHit();
        }
    }
}
