using UnityEngine;

public class PlayerLookAtMouse : MonoBehaviour
{
    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float distance;

        if (groundPlane.Raycast(ray, out distance))
        {
            Vector3 mousePos = ray.GetPoint(distance);

            Vector3 direction = mousePos - transform.position;

            direction.y = 0;

            if (direction.sqrMagnitude > 0.01f)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}