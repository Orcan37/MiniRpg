using System.Collections;
using System.Collections.Generic;
using System.Threading;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CodeBase.Logic.Ads
{
    public class popUpMassageDisplay : MonoBehaviour
    {
 
        public TextMeshProUGUI popUptext;
        public GameObject panel;

        public Animator anim;

        CollectionAd _сollectionAd;
        public ICanvasTestItem _canvasTestItem;
    
        // public ISaveLoadService _saveLoadService;
        public Color GizCol = new Color32(30, 200, 30, 130);
        public string debugText = "BoxCollider";

        public virtual void Start()
        {
            _canvasTestItem = AllServices.Container.Single<ICanvasTestItem>();
            //      panel = this.gameObject.transform.GetChild(0).gameObject;
            popUptext = panel.GetComponent<TextMeshProUGUI>();
            anim = GetComponent<Animator>();
            panel.SetActive(false);
            _сollectionAd = this.GetComponent<CollectionAd>();
            //     AnimClose();
        }

        private bool banimShow = true;

        public void AnimClose()
        {
            Debug.Log("close");
            anim.ResetTrigger("close");
            anim.ResetTrigger("show");
            anim.ResetTrigger("switch");
            anim.SetTrigger("close");
            panel.gameObject.SetActive(false);
            banimShow = true;
        }


        public void AnimShow(int count)
        {
            Debug.Log("show");

            if (banimShow)
            {
                banimShow = false;
                // if(panel != null) {   panel.gameObject.SetActive(true);}  else{   Debug.Log("null");  banimShow = true; return;   }
                anim.ResetTrigger("show");
                anim.ResetTrigger("close");
                anim.ResetTrigger("switch");
                anim.SetTrigger("show");
                panel.gameObject.SetActive(true);
                ItemAdd(count);
            }

            banimShow = true;
        }

        public void AnimSwitch(int count)
        {
            Debug.Log("switch");
            panel.gameObject.SetActive(true);
            anim.ResetTrigger("switch");
            anim.ResetTrigger("show");
            anim.ResetTrigger("close");
            anim.SetTrigger("switch");
            ItemAdd(count);
        }

        public void ItemAdd(int count)
        {
            Debug.Log("ItemAdd Money" + _canvasTestItem.money);
            if (_canvasTestItem != null)
            {
                _canvasTestItem.money += count;
            }
            else
            {
                return;
            }

            popUptext.text = "Money = " + _canvasTestItem.money.ToString();
            banimShow = false;
            Invoke(nameof(AnimClose), 2f);

            //= " +  _canvasTestItem.test());
            // Debug.Log("money = " +  _canvasTestItem.money);
        }
        // void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.C))
        //     {
        //         AnimClose();
        //     }
        //     if (Input.GetKeyDown(KeyCode.V))
        //     {
        //         AnimShow();
        //     }
        //     if (Input.GetKeyDown(KeyCode.S))
        //     {
        //         AnimSwitch();
        //     }
        // }

        private void OnEnable()
        {
//        listsMassageDisplay.PopUpMassageDisplay = this;
        }
        // void Awake()
        // {
        //     // if (listsMassageDisplay == null)
        //     // {
        //     //     listsMassageDisplay = GameObject.FindGameObjectWithTag("Menus").GetComponent<ListsMassageDisplay>(); //   
        //     // } 
        // } 



    }
}
