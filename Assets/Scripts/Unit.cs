using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float stoppingDistance = .1f;
    [SerializeField] private Animator unitAnimator;

    [SerializeField] float rotateSpeed = 10f;

    private void Awake()
    {
        targetPosition = transform.position;
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


    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
