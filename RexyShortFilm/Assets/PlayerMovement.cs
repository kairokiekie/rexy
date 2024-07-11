using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int _MaxRayCastDistance = 10;
    [SerializeField] private LayerMask _Mask = default;
    [SerializeField] private GameObject toHideOrShow = default;
    [SerializeField] private GameObject uiWheel;
    [SerializeField] private GameObject uiCanvas;

    private Camera _Camera;

    private void Start()
    {
        _Camera = Camera.main;
    }

    private void Update()
    {
        if (_Camera == null) return;
        Ray lRay = _Camera.ScreenPointToRay(Input.mousePosition);

        bool lHitSomething = Physics.Raycast(lRay, out RaycastHit hitInfo, _MaxRayCastDistance, _Mask);

        if (lHitSomething)
        {
            var eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results); //this for UI detection

            //Check for left click
            if (Input.GetMouseButtonDown(0))
            {
                if (uiWheel.activeSelf == true && results.Where(r => r.gameObject.layer == 5).Count() <= 0)
                {
                    print(hitInfo.transform.gameObject.layer);
                    uiWheel.SetActive(false);
                }
                else if (uiWheel.activeSelf == false)
                {
                    uiWheel.SetActive(true);
                    uiWheel.transform.position = Input.mousePosition;
                }
            }

        }

        toHideOrShow.SetActive(lHitSomething);
        toHideOrShow.transform.position = hitInfo.point;
    }
}