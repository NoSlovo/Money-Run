using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLevel : MonoBehaviour
{
    [SerializeField] private float _moveSpead;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(_moveSpead * -1 * Time.deltaTime, 0, 0);
    }

}
