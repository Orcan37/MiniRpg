using System;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public class GameRunner : MonoBehaviour
  {
    public GameBootstrapper BootstrapperPrefab;
    
    private void Awake()
    {
      if (FindObjectOfType<GameBootstrapper>() == null)
        Instantiate(BootstrapperPrefab);
    }
  }
}