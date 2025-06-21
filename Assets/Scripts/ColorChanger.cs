using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _changedMaterial;

    private IColorChangeNotifier _colorChangeNotifier;

    private void Awake()
    {
        _colorChangeNotifier = GetComponent<IColorChangeNotifier>();
    }

    private void OnEnable()
    {
        _renderer.material = _defaultMaterial;
        _colorChangeNotifier.StatusChanged += Change;
    }

    private void OnDisable()
    {
        _colorChangeNotifier.StatusChanged -= Change;
    }

    private void Change()
    {
        _renderer.material = _changedMaterial;
    }
}
