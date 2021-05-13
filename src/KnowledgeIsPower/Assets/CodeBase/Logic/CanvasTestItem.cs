using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using CodeBase.Infrastructure;
using CodeBase.Logic.Ads;
using UnityEngine;
public class CanvasTestItem : ICanvasTestItem //, ICoroutineRunner
{
    public int money { get; set; }
  public int diamond { get; set; }
  private GameObject _canvaspopUp;
  private popUpMassageDisplay _popUpMassageDisplay;
  private ICoroutineRunner coroutineRunnerImplementation;
  public   CanvasTestItem()
  {
   if(_canvaspopUp == null)      _canvaspopUp = GameObject.FindWithTag("CanvaspopUp"); 
      // Debug.Log("Super");
      // Debug.Log("_canvaspopUp = " + _canvaspopUp.gameObject.name);
   if(_popUpMassageDisplay != null && _canvaspopUp != null)     _popUpMassageDisplay = _canvaspopUp.GetComponentInChildren<popUpMassageDisplay>(); 
   //   Debug.Log("_popUpMassageDisplay = " + _popUpMassageDisplay.gameObject.name);
     // _popUpMassageDisplay.gameObject.SetActive(false);
      // _saveLoadService = AllServices.Container.Single<ISaveLoadService>
  }
  public void AnimShow(int count)
  {
      _canvaspopUp = GameObject.FindWithTag("CanvaspopUp"); 
      _popUpMassageDisplay = _canvaspopUp.GetComponentInChildren<popUpMassageDisplay>(); 
      Debug.Log("_popUpMassageDisplay = " + _popUpMassageDisplay.gameObject.name);
      _popUpMassageDisplay.AnimShow(count);
  }
 
}