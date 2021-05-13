using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Enemy
{
  public class Aggro : MonoBehaviour
  {
    [SerializeField] private TriggerObserver _triggerObserver;
    [SerializeField] private Follow _follow;
    [SerializeField] private float _cooldown;
    
    private Coroutine _followOffCoroutine;
    private bool _hasAggroTarget;

    private void Start()
    {
      _triggerObserver.TriggerEnter += OnTriggerEnter;
      _triggerObserver.TriggerExit += OnTriggerExit;

      SwitchFollowOff();
    }

    private void OnTriggerExit(Collider obj)
    {
      if (_hasAggroTarget)
      {
        _hasAggroTarget = false;
        _followOffCoroutine = StartCoroutine(SwitchFollowOffAfterCooldown());
      }
    }

    private void OnTriggerEnter(Collider obj)
    {
      if (!_hasAggroTarget)
      {
        _hasAggroTarget = true;
        StopFollowOffCoroutine();
        SwitchFollowOn();
      }
    }
    
    private void StopFollowOffCoroutine()
    {
      if (_followOffCoroutine != null)
      {
        StopCoroutine(_followOffCoroutine);
        _followOffCoroutine = null;
      }
    }

    private IEnumerator SwitchFollowOffAfterCooldown()
    {
      yield return new WaitForSeconds(_cooldown);
      SwitchFollowOff();
    }

    private void SwitchFollowOn() => 
      _follow.enabled = true;

    private void SwitchFollowOff() => 
      _follow.enabled = false;
  }
}