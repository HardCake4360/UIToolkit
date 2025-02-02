using UnityEngine;
using UnityEngine.UIElements;

public class SimpleRuntimeUI : MonoBehaviour
{
    private Button _button;
    private Button _button2;
    private Toggle _toggle;

    private VisualElement _sprite;

    private int _clickCount;

    //Add logic that interacts with the UI controls in the `OnEnable` methods
    private void OnEnable()
    {
        // The UXML is already instantiated by the UIDocument component
        var uiDocument = GetComponent<UIDocument>();

        _button = uiDocument.rootVisualElement.Q("button") as Button;
        _button2 = uiDocument.rootVisualElement.Q("button2") as Button;
        _toggle = uiDocument.rootVisualElement.Q("toggle") as Toggle;
        _sprite = uiDocument.rootVisualElement.Q("sprite") as VisualElement;

        _button.RegisterCallback<ClickEvent>(PrintClickMessage);
        _button2.RegisterCallback<ClickEvent>(OnClick);

        var _inputFields = uiDocument.rootVisualElement.Q("input-message");
        _inputFields.RegisterCallback<ChangeEvent<string>>(InputMessage);
    }

    private void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(PrintClickMessage);
        _button2.UnregisterCallback<ClickEvent>(OnClick);
    }

    private void PrintClickMessage(ClickEvent evt)
    {
        ++_clickCount;

        Debug.Log($"{"button"} was clicked!" +
                (_toggle.value ? " Count:" + _clickCount : ""));
    }
    private void OnClick(ClickEvent evt)
    {
        Debug.Log("sdjf;alkjdas;lfkjsa;dlfj");
        _sprite.SetEnabled(false);
    }

    public static void InputMessage(ChangeEvent<string> evt)
    {
        Debug.Log($"{evt.newValue} -> {evt.target}");
    }
}