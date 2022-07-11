using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MoveCard : MonoBehaviour
{
    [SerializeField] private Transform _movePoint;
    [SerializeField] private Transform[] _endPoints;
    [SerializeField] private SpawnPoint _spawn;

    public  UnityAction<int> CardMove;

    private Sequence _myRotate;

    private void Start()
    {
        RotationCard();
    }

    public void MoveCardPoint(int weaponNumber)
    {
        transform.DORotate(new Vector3(270.357f, 90, -176.266f), 0);

        int indexPoint;

        if (weaponNumber >= 2)
        {
            indexPoint = 0;
        }
        else
        {
            indexPoint = 1;
        }

        Sequence _mySequence = DOTween.Sequence();
        _mySequence = _mySequence.Append(transform.DOLocalMove(_movePoint.transform.localPosition, 0.6f).OnComplete(() => transform.DORotate(new Vector3(360, 90, 180), 0.7f)));
        _mySequence = _mySequence.Append(transform.DOLocalMove(_endPoints[indexPoint].transform.localPosition, 1.3f)).OnStart(() => transform.DOScale(new Vector3(0.47f, 0.27f, 0.43f), 0.235f)).OnComplete(() => StartCoroutine(DestroyCard(weaponNumber)));
    }

    private void RotationCard()
    {
        _myRotate = DOTween.Sequence();
        _myRotate.Append(transform.DORotate(new Vector3(270.357f, 100, -176.266f), 1f)).SetLoops(-1, LoopType.Yoyo);
    }

    private IEnumerator DestroyCard(int PlayerWeaponCount)
    {
        var waitForSecondsRealtime = new WaitForSecondsRealtime(1.5f);
        CardMove?.Invoke(PlayerWeaponCount);
        yield return waitForSecondsRealtime;

        transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.6f).OnComplete(() => Destroy(this.gameObject));
    }

    public void KillSequence()
    {
        _myRotate.Kill();
    }
}
