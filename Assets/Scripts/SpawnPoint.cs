using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(ParticleSystem))]

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Weapon _waepon;
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _rotationWeapon;
    [SerializeField] private Vector3 _scaleWeapon;
    [SerializeField] private Card _card;
    [SerializeField] private Transform _presentationPoint;
    [SerializeField] private Transform[] _playerWeaponPoints;
    [SerializeField] private MoveCard _moveCard;

    private void OnEnable()
    {
        _moveCard.CardMove += SpawnWapon;
    }

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        _particleSystem.Stop();
    }

    private void SpawnWapon(int indexPont)
    {
        Sequence _mySequence = DOTween.Sequence();
        var weapon = Instantiate(_waepon, transform.localPosition, Quaternion.identity);
        _particleSystem.Play();
        weapon.transform.SetParent(_card.transform, false);
        weapon.MoveWeapon(_presentationPoint, _playerWeaponPoints[indexPont - 1],_player);

        SetParameters(weapon);
    }


    private void SetParameters(Weapon weapon)
    {
        weapon.transform.localScale = _scaleWeapon;
        weapon.transform.eulerAngles = _rotationWeapon;
        weapon.transform.localScale = _scaleWeapon;
        weapon.transform.eulerAngles = _rotationWeapon;
    }

    private void OnDisable()
    {
        _moveCard.CardMove -= SpawnWapon;
    }

}