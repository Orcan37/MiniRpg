using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Enemy
{
  public class RotateToHero : Follow
  {
    [SerializeField] private float _speed;
    
    private IGameFactory _gameFactory;
    private Transform _heroTransform;

    private void Start()
    {
      _gameFactory = AllServices.Container.Single<IGameFactory>();
      
      if (HeroExists())
        InitializeHeroTransform();
      else 
        _gameFactory.HeroCreated += OnHeroCreated;
    }

    private void Update()
    {
      if (Initialized())
        RotateTowardHero();
    }

    private GameObject HeroExists() => 
      _gameFactory.HeroGameObject;

    private bool Initialized() => 
      _heroTransform;

    private void RotateTowardHero() => 
      transform.rotation = SmoothedRotation(transform.rotation, PositionToLook());

    private Quaternion SmoothedRotation(Quaternion rotation, Vector3 positionToLook) => 
      Quaternion.Lerp(rotation, TargetRotation(positionToLook), SpeedFactor());

    private static Quaternion TargetRotation(Vector3 position) => 
      Quaternion.LookRotation(position);

    private Vector3 PositionToLook()
    {
      Vector3 position = _heroTransform.position - transform.position;
      position.y = transform.position.y;
      return position;
    }

    private float SpeedFactor() => 
      Time.deltaTime * _speed;

    private void InitializeHeroTransform() => 
      _heroTransform = _gameFactory.HeroGameObject.transform;

    private void OnHeroCreated() => 
      InitializeHeroTransform();
  }
}