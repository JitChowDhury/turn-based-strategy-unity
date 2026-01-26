using System.IO.Compression;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridDebugObject : MonoBehaviour
{
    private GridObject gridObject;
    private TextMeshPro textMesh;

    void Awake()
    {
        textMesh = GetComponentInChildren<TextMeshPro>();
    }

    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
        textMesh.text = gridObject.ToString();
    }


}
