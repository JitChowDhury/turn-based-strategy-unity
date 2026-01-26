using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Transform gridDebugPrefab;
    GridSystem grid;
    void Start()
    {
        grid = new GridSystem(10, 10, 2f);
        grid.CreteDebugObject(gridDebugPrefab);
    }

    void Update()
    {
        Debug.Log(grid.GetGridPosition(MouseWorld.GetPosition()));
    }


}
