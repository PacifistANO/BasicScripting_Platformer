using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    private Transform[] _points;
    private int _currentPoint = 0;

    private void Start()
    {
        _spriteRenderer= GetComponent<SpriteRenderer>();
        _points= new Transform[_path.childCount];

        for(int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _spriteRenderer.flipX = false;
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _spriteRenderer.flipX = true;
                _currentPoint = 0;
            }
        }
    }
}
