using DG.Tweening;
using UnityEngine;

public class MoveTo : BaseAction
{
    [SerializeField] private Vector3 _position;

    protected override void PerformAction()
    {
        transform.DOMove(_position, _duration).SetLoops(_repeats, _loopType);
    }
}
