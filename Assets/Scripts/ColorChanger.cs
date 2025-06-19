using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material _enemyMaterial;
    [SerializeField] private Material _deadMaterial;

    private EnemyBehavior _enemy;
    private Renderer _renderer;

    private void Awake()
    {
        _enemy = GetComponent<EnemyBehavior>();
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            if (renderer.gameObject.name == "Body")
            {
                _renderer = renderer;
            }
        }
    }

    private void OnEnable()
    {
        _renderer.material = _enemyMaterial;
        _enemy.Crashed += Change;
    }

    private void OnDisable()
    {
        _enemy.Crashed -= Change;
    }

    private void Change(EnemyBehavior enemy)
    {
        _renderer.material = _deadMaterial;
    }
}
