using UnityEngine;
using TMPro;
using System.Text;

public class UIPanelDebug : MonoBehaviour
{
    public TextMeshProUGUI _text_fps;
    public TextMeshProUGUI _text_log;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        Application.logMessageReceivedThreaded += _on_handle_log;
    }

    private void OnDisable()
    {
        Application.logMessageReceivedThreaded += _on_handle_log;
    }

    void _on_handle_log(string logString, string stackTrace, LogType type)
    {
        var content = $"[{type.ToString().ToUpper()}]{logString}\n{stackTrace}";

        switch (type)
        {
            case LogType.Exception:
            case LogType.Error:
                content = $"<color=red>{content}</color>";
                break;
            case LogType.Warning: content = $"<color=yellow>{content}</color>";
                break;
            case LogType.Assert:
            case LogType.Log: content = $"<color=green>{content}</color>";
                break;
        }

        _text_log.text = $"{content}\n" + _text_log.text;
    }

    void Update()
    {
        _text_fps.text = "FPS: " + (int)(1.0f / Time.unscaledDeltaTime);
    }
}
