 
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SaveLoad;
using UniRx;
using UnityEngine;

public class Ad : MonoBehaviour
{ 
    public ICanvasTestItem _canvasTestItem; 
    public string debugText = "Collider Ad";
    public bool _quickAccrual = true;
    public float returnActive = -1;
    private int count = 0;
    
    public virtual void Awake()
    { 
        _canvasTestItem   = AllServices.Container.Single<ICanvasTestItem>();
    }

    public virtual bool CheckAndDelete()
    {
        QuickAccrual(); 
        return true; 
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        CheckAndDelete();
    } 
    
    
    public virtual void QuickAccrual()
    {
        if (_quickAccrual)
        {
          
            _canvasTestItem.AnimShow(count);
            ReturnActive();
        }
    }
   
    public virtual void ReturnActive() 
    {
        if(returnActive != -1){
            Observable.Timer(System.TimeSpan.FromSeconds(returnActive))  
                .Subscribe(_ =>
                {
                    StatusActiveThisObject(true);
                    _quickAccrual = true;
                });   
        } 
        StatusActiveThisObject(false);
    }
    public virtual void StatusActiveThisObject(bool status) => gameObject.SetActive(status);
  
}
