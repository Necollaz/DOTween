using DG.Tweening;
using UnityEngine;

public class ScaleTo : BaseAction
{
    [SerializeField] private Vector3 _targetScale;

    protected override void PerformAction()
    {
        transform.DOScale(_targetScale, _duration).SetLoops(_repeats, _loopType);
    }
}
