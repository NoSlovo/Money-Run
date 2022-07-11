using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed = 2.0F;

    private int _money;
    private CharacterController _characterController;
    private int _weaponCount = 0;

    public event  UnityAction ChengMoney;

    public int Money => _money;
    public int WeaponCount => _weaponCount;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void OnMouseDrag()
    {
        float horizont = _horizontalSpeed * Input.GetAxis("Mouse X");
        _characterController.Move(new Vector3(0, 0, horizont * -1));
    }

    private void SetWeapon() =>_weaponCount++;

    public void SetValueMoney(int value)
    {
        if (value != 0)
        {
            _money += value;
            ChengMoney?.Invoke();
        }
    }

    public void BuyCard(Card card)
    {
        if (card != null && card.PriceCard > 0)
        {
           SetWeapon();
           _money -= card.PriceCard;
           ChengMoney?.Invoke();
        }
    }
}
