using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationSlicer : MonoBehaviour
{
    private Animator _animator;
    private readonly float _timeDisableAnimator = 3.3f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        Invoke(nameof(DisableAnimator), _timeDisableAnimator);
    }

    private void DisableAnimator()
    {
        _animator.enabled = false;
    }
}
