using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class Card : MonoBehaviour
{
    [SerializeField] private MoveCard _moveCard;
    [SerializeField] private Card _cardTwo;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PriceBarCard _priceBarCard;
    [SerializeField] private int _priceCard;

    public int PriceCard => _priceCard;

    private BoxCollider _collider;


    private void Start()
    {
        
        _collider = GetComponent<BoxCollider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (player.Money >= _priceCard)
            {
                player.BuyCard(this);
                transform.SetParent(player.transform, true);
                _moveCard.MoveCardPoint(player.WeaponCount); 
                OffElements();
                _cardTwo.OffElements();
                _moveCard.KillSequence();
            }
        }
    }

    public void OffElements()
    {
        _priceBarCard.OffBardMoney();
        _collider.enabled = false;
        _spriteRenderer.enabled = false;
    }

}
