using UnityEngine;

public class Testing : MonoBehaviour
{
    GridSystem grid;
    void Start()
    {
        grid = new GridSystem(10, 10, 2f);
    }

    void Update()
    {
        Debug.Log(grid.GetGridPosition(MouseWorld.GetPosition()));
    }


}
