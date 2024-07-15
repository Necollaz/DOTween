using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    private enum ChangeMode { Replace, Add, EffectReplace }

    [SerializeField] private Text _text;
    [SerializeField] private float _duration = 3f;
    [SerializeField] private string[] _message;
    [SerializeField] private int _loopInterval = 3;
    [SerializeField] private int _callbackTrigger = 2;

    private string _initialText = "";
    private delegate void ChangeMethod(string message, TweenCallback onComplete);

    private void Start()
    {
        if (_text != null && _message.Length > 0)
        {
            _initialText = _text.text;
            Changed(0);
        }
    }

    private void Changed(int index)
    {
        if (index >= _message.Length)
        {
            Changed(0);
            return;
        }

        string message = _message[index];
        int modeIndex = index % _loopInterval;

        ChangeMethod[] changeMethods = new ChangeMethod[] { Replace, Add, EffectReplace };

        changeMethods[modeIndex](message, () => {
            if (index % _loopInterval == _callbackTrigger)
            {
                Reset();
            }
            Changed(index + 1);
        });

    }

    private void Replace(string message, TweenCallback onComplete)
    {
        _text.DOText(message, _duration).OnComplete(onComplete);
    }

    private void Add(string message, TweenCallback onComplete)
    {
        _text.DOText(_text.text + message, _duration).OnComplete(onComplete);
    }

    private void EffectReplace(string message, TweenCallback onComplete)
    {
        _text.DOText(message, _duration, true, ScrambleMode.All);
        _text.DOColor(Color.red, _duration).OnComplete(onComplete);
    }

    private void Reset()
    {
        _text.text = _initialText;
        _text.color = Color.black;
    }
}
