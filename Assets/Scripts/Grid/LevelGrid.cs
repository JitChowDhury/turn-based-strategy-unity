using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance { get; private set; }
    [SerializeField] private Transform gridDebugPrefab;
    GridSystem grid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {

        if (Instance != null)
        {
            Debug.LogError("There's more than one LevelGrid!" + transform + "-" + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        grid = new GridSystem(10, 10, 2f);
        grid.CreteDebugObject(gridDebugPrefab);
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = grid.GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }
    public List<Unit> GetUnitAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = grid.GetGridObject(gridPosition);
        return gridObject.GetUnitList();
    }
    public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = grid.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }

    public GridPosition GetGridPosition(Vector3 worldPos) => grid.GetGridPosition(worldPos);

    public void UnitMovedGridPosition(Unit unit, GridPosition fromGridPosition, GridPosition toGridPosition)
    {
        RemoveUnitAtGridPosition(fromGridPosition, unit);
        AddUnitAtGridPosition(toGridPosition, unit);
    }
}
