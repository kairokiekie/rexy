using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    private int _MaxRayCastDistance = 1000;
    [SerializeField] private LayerMask _Mask = default;
    [SerializeField] private LayerMask _UIMask = default;
    [SerializeField] private GameObject toHideOrShow = default;

    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private GameObject moveWheel;
    [SerializeField] private GameObject objectWheel;
    [SerializeField] private float objectStoppingDistance = 3f;
    [SerializeField] private float movementStoppingDistance = 0.5f;
    [SerializeField] private GameObject canvasManager;

    private RaycastHit _hitInfo;
    private Camera _Camera;
    private GameObject _currentObjectSelection;
    private Animator _animator;
    private NavMeshAgent agent;
    private Vector3 target;

    private bool idleAnimation = false;
    [SerializeField] public GameObject currentPlayer;

    private void Start()
    {
        _Camera = Camera.main;
        target = toHideOrShow.transform.position;

        SwitchPlayer(currentPlayer);
        //currentPlayer = canvasManager.GetComponent<PlayerActions>().currentPlayer;
    }

    private void Update()
    {
        if (_Camera == null) return;
        Ray lRay = _Camera.ScreenPointToRay(Input.mousePosition);

        bool lHitSomething = Physics.Raycast(lRay, out RaycastHit hitInfo, _MaxRayCastDistance, _Mask);
        bool uiInteraction = Physics.Raycast(lRay, out RaycastHit UIhitInfo, _MaxRayCastDistance, _UIMask);
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
                //else if (objectWheel.activeSelf || moveWheel.activeSelf && results.Where(r => r.gameObject.layer == 5).Count() <= 0) //if click off ui
                
                else if (hitInfo.transform.gameObject.layer == 6 && results.Where(r => r.gameObject.layer == 9).Count() <= 0) // if nothing else, and click on floor
                {
                    print("stoppit");
                    moveWheel.SetActive(true);
                    objectWheel.SetActive(false);
                    moveWheel.transform.position = Input.mousePosition;
                }
                else if (objectWheel.activeSelf && hitInfo.transform.gameObject.layer != 5)
                {
                    moveWheel.SetActive(false);
                    objectWheel.SetActive(false);
                }



            }

        }

        if (currentPlayer.gameObject.transform.position.x == target.x && currentPlayer.gameObject.transform.position.z == target.z)
        {
            ArrivedAtPos();
        }

        toHideOrShow.SetActive(lHitSomething);
        toHideOrShow.transform.position = hitInfo.point;
    }

    private void ArrivedAtPos()
    {
            if (!idleAnimation)
            {
                _animator.SetTrigger("idle");
                idleAnimation = true;

            }


    }

    // The following functions are called by UI buttons
    public void MoveToTarget()
    {
        moveWheel.SetActive(false);
        _currentObjectSelection = null;

        agent.stoppingDistance = movementStoppingDistance;
        WalkCycle();

        
    }

    public void InteractWithObject()
    {
        objectWheel.SetActive(false);
        _currentObjectSelection = _hitInfo.transform.gameObject;
        _currentObjectSelection.transform.GetChild(1).gameObject.SetActive(true);

        agent.stoppingDistance = objectStoppingDistance;
        WalkCycle();

    }

    public void WalkCycle()
    {
        target = toHideOrShow.transform.position;

        _animator.SetTrigger("walk");
        idleAnimation = false;

        agent.destination = target;
    }

    // These functions are called by other game objects

    public void ArrivedAtObject(AnimationClip _anim)
    {
        //so on trigger enter, if player, do anims:
        print("interact anim " + _anim.name);
        print(currentPlayer);
        _animator.Play(_anim.name);
    }

    public void SwitchPlayer(GameObject newPlayer)
    {
        currentPlayer = newPlayer;
        print("new player: " + newPlayer);
        _animator = currentPlayer.transform.GetChild(0).GetComponent<Animator>();
        print(_animator);
        agent = currentPlayer.transform.GetComponent<NavMeshAgent>();
    }



}
