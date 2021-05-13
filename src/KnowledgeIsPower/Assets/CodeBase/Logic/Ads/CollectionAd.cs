using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Logic.Ads
{
    public class CollectionAd : MonoBehaviour
    {
        private List<Ad> CollectionAds;
        public popUpMassageDisplay[] PopUpMassageDisplay; 
        public float IntervalSwich = 1; // - проверяет есть ли Листы в наличии  постояное количесво времени 
        public float dissmisTime = 5; // из объявление  вытаскивается 
        public float musicNum = 0; // из объявление вытаскивается какую мелодию сыиграть 
        // [Header("Вспомогательные ")] 
        // private bool pupapOpen = false; 
        // private int engineNumList = -1; 
        // private int engineNumDelete = -1;

        private void RefreshpopUpList()
        {
            
        }
    }
} 