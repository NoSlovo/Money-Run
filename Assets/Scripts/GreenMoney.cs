using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class GreenMoney : MonoBehaviour
{
    [SerializeField] private MeshRenderer _mRender;
    [SerializeField] private ParticleSystem _particle;

    private const int _moneyPrise = 10;

    private void Awake()
    {
        _mRender = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        
        _particle.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _particle.Play();
            _mRender.enabled = false;
            player.SetValueMoney(_moneyPrise);
        }
    }
}
