using UnityEngine;
using System.Collections;
using DG.Tweening;
using BzKovSoft.ObjectSlicerSamples;

public class Slicer : MonoBehaviour
{
    [SerializeField] private GameObject _blade;
    [SerializeField] private float _duration;
    [SerializeField] private float _offsetY;
    [SerializeField] private float _timeDelay;

    private BzKnife _knife;
    private float _time;

    private bool _isStunning;
    private readonly float _timeStunning = 3f;

    private void Start()
    {
        _knife = _blade.GetComponentInChildren<BzKnife>();
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time > _timeDelay && !_isStunning)
        {
            if (Input.GetMouseButton(0))
            {
                _knife.BeginNewSlice();

                _blade.transform.DOMoveY(_blade.transform.position.y - _offsetY, _duration).SetLoops(2, LoopType.Yoyo);
                _time = 0;
            }
        }
    }

    public void Stunning()
    {
        StartCoroutine(EnableStunning());
    }

    IEnumerator EnableStunning()
    {
        _isStunning = true;

        yield return new WaitForSeconds(_timeStunning);

        _isStunning = false;
    }
}
