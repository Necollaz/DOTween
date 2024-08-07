using DG.Tweening;
using UnityEngine;

public class Rotation : Basic
{
    [SerializeField] private Vector3 _rotation;

    protected override void PerformAction()
    {
        transform.DORotate(_rotation, _duration, RotateMode.FastBeyond360)
            .SetLoops(_repeats, _loopType);
    }
}
