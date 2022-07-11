using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offSet;

    private float _smooth = 4.5f;


    private void Update()
    {
       transform.position = Vector3.Lerp(transform.position,_target.position + _offSet, Time.deltaTime  * _smooth);
    }
}
