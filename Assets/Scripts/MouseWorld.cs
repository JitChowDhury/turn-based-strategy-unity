using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld Instance;
    // Update is called once per frame
    [SerializeField] private LayerMask mousePlaneLayerMask;

    void Awake()
    {
        Instance = this;
    }
    void Update()
    {

        transform.position = GetPosition();
    }

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, Instance.mousePlaneLayerMask);
        return raycastHit.point;
    }
}
