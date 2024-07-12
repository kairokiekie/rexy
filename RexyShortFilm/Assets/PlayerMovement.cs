using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    private int _MaxRayCastDistance = 1000;
    [SerializeField] private LayerMask _Mask = default;
    [SerializeField] private GameObject toHideOrShow = default;

    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private GameObject moveWheel;
    [SerializeField] private GameObject objectWheel;
    [SerializeField] private float objectStoppingDistance = 3f;
    [SerializeField] private float movementStoppingDistance = 0.5f;

    private RaycastHit _hitInfo;
    private Camera _Camera;
    private GameObject _currentObjectSelection;

    private void Start()
    {
        _Camera = Camera.main;
    }

    private void Update()
    {
        if (_Camera == null) return;
        Ray lRay = _Camera.ScreenPointToRay(Input.mousePosition);

        bool lHitSomething = Physics.Raycast(lRay, out RaycastHit hitInfo, _MaxRayCastDistance, _Mask);
        _hitInfo = hitInfo;

        if (lHitSomething)
        {
            var eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results); // all this for UI detection

            //Check for left click
            if (Input.GetMouseButtonDown(0))
            {
                if (hitInfo.transform.gameObject.layer == 7) //if click on object
                {
                    moveWheel.SetActive(false);
                    objectWheel.SetActive(true);
                    objectWheel.transform.position = Input.mousePosition;
                }
                else if (objectWheel.activeSelf || moveWheel.activeSelf && results.Where(r => r.gameObject.layer == 5).Count() <= 0) //if click off ui
                {
                    moveWheel.SetActive(false);
                    objectWheel.SetActive(false);
                }
                else if (moveWheel.activeSelf == false) // if nothing else, and click on floor
                {
                    moveWheel.SetActive(true);
                    objectWheel.SetActive(false);
                    moveWheel.transform.position = Input.mousePosition;
                }


                
            }

        }

        toHideOrShow.SetActive(lHitSomething);
        toHideOrShow.transform.position = hitInfo.point;
    }

    public void InteractWithObject()
    {
        objectWheel.SetActive(false);
        _currentObjectSelection = _hitInfo.transform.gameObject;

        NavMeshAgent agent = GetComponent<NavMeshAgent>(); //clean this (global navmesh agent name case)
        agent.stoppingDistance = objectStoppingDistance;
        agent.destination = _hitInfo.transform.position;

    }
    private void ArrivedAtObject()
    {
        //uwu
    }

    public void MoveToTarget()
    {
        moveWheel.SetActive(false);
        _currentObjectSelection = _hitInfo.transform.gameObject;

        Vector3 target = toHideOrShow.transform.position;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = movementStoppingDistance;
        agent.destination = target;
    }

    
}
