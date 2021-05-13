using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.Logic
{
    public class BoxTrigger : MonoBehaviour
    {
        public BoxCollider Collider;

        public ISaveLoadService _saveLoadService;
        public Color GizCol = new Color32(30, 200, 30, 130);
        public string debugText = "BoxCollider";

        public virtual void Awake() =>   _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
        
        public virtual void OnTriggerEnter(Collider other) =>  StatusActiveThisObject(false);
        
        public virtual void StatusActiveThisObject(bool status) => gameObject.SetActive(status);

        private void OnDrawGizmos()
        {
            if (!Collider)
                return;
            Gizmos.color = GizCol;
            Gizmos.DrawCube(transform.position + Collider.center, Collider.size);
        }
    }
}
 
