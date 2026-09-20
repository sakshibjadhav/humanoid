using UnityEngine;
using UnityEngine.Events;

public class ARTapToPlace : MonoBehaviour
{
    [SerializeField] private AvatarImporter avatarImporter;
    [SerializeField] Camera arCam;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCam.ScreenPointToRay(touch.position);
                RaycastHit hitAnything;

                if (Physics.Raycast(ray, out hitAnything, Mathf.Infinity))
                {
                    StorePosition(hitAnything);
                }
            }

        }
    }

    private void StorePosition(RaycastHit hitAnything)
    {
        if (hitAnything.transform.gameObject.CompareTag("Floor"))
        {
            if (avatarImporter.avatar.activeSelf == false)
            {
                avatarImporter.avatar.SetActive(true);
                avatarImporter.avatar.transform.rotation = hitAnything.transform.rotation;
                avatarImporter.avatar.transform.position = hitAnything.point;
            }
            
        }
    }
}