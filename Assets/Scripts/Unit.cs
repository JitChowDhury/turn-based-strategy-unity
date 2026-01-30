using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;
    private GridPosition currentGridPos;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float stoppingDistance = .1f;
    [SerializeField] private Animator unitAnimator;

    [SerializeField] float rotateSpeed = 10f;

    private void Awake()
    {
        targetPosition = transform.position;
    }

    void Start()
    {
        currentGridPos = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(currentGridPos, this);
    }


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(targetPosition, transform.position) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;


            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
            unitAnimator.SetBool("IsWalking", true);
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);

        }
        GridPosition newGridPos = LevelGrid.Instance.GetGridPosition(transform.position);
        if (newGridPos != currentGridPos)
        {
            LevelGrid.Instance.UnitMovedGridPosition(this, currentGridPos, newGridPos);
            currentGridPos = newGridPos;
        }

    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }


}
