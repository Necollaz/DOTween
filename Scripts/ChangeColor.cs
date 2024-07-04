using DG.Tweening;
using UnityEngine;

public class ChangeColor : BaseAction
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _color;

    protected override void PerformAction()
    {
        _spriteRenderer.DOColor(_color, _duration).SetLoops(_repeats, _loopType);
    }
}
