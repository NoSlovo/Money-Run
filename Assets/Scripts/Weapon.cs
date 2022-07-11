using DG.Tweening;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool _reachedThePoint = false;
    private Transform _point;

    private void Update()
    {
        FollowThePoint();
        RotationWeapon();
    }



    public void MoveWeapon(Transform movePoint, Transform endPoint,Player player)
    {
        _point = endPoint;
        Sequence _mySequence = DOTween.Sequence();
        _mySequence.Append(transform.DOLocalMove(movePoint.transform.localPosition, 1.1f));
        _mySequence.Append(transform.DOMove(endPoint.transform.position, 0.4f)).OnComplete(() => _reachedThePoint = true);
    }

    private void RotationWeapon()
    {
        transform.Rotate(0, 0.245f, 0, Space.World);
    }

    private void FollowThePoint()
    {   
        if (_reachedThePoint)
        {
            transform.SetParent(null);
            transform.DOMove(_point.transform.position, 0.8f);
        }
    }
}
