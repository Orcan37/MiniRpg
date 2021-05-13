
using UnityEngine;

namespace CodeBase.Logic
{
  public class SaveTrigger : BoxTrigger
  {  
    public override void OnTriggerEnter(Collider other)
    {
      _saveLoadService.SaveProgress();
      Debug.Log(debugText);
      StatusActiveThisObject(false);
    }

  
  }
}