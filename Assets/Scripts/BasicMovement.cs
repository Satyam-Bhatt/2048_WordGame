using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private Vector3 mousePosition_OnClick, mousePosition_OnRelease;
    private RaycastHit2D hit;

    [SerializeField] private float moveDistance = 1f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private bool slide = false; //this should be on the gameobject to be moved

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = new Ray(mousePosition, Vector3.forward);
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            mousePosition_OnClick = mousePosition;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && hit.collider != null)
        {
            mousePosition_OnRelease = mousePosition;

            Vector3 direction = (mousePosition_OnRelease - mousePosition_OnClick).normalized;
            Rigidbody2D rb = hit.collider.GetComponent<Rigidbody2D>();

            if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (slide)
                {
                    rb.velocity = new Vector2(direction.x / Mathf.Abs(direction.x) * moveSpeed, 0);
                }
                else
                {
                    hit.transform.position += new Vector3(direction.x/Mathf.Abs(direction.x) *  moveDistance, 0, 0);
                }
            }
            else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
            {
                if (slide)
                {
                    rb.velocity = new Vector2(0, (direction.y / Mathf.Abs(direction.y)) * moveSpeed);
                }
                else
                {
                    hit.transform.position += new Vector3(0, (direction.y / Mathf.Abs(direction.y)) * moveDistance, 0);
                }
            }
        }
    }
}
