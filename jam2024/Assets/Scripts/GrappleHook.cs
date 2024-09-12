using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour {
    [SerializeField] private LineRenderer rope;

    [SerializeField] LayerMask grappableMask;
    [SerializeField] float maxDistance = 10f;
    [SerializeField] float grappableSpeed = 10f;
    [SerializeField] float grappableShootSpeed = 20f;

    bool isGrappling = false;
    [HideInInspector] public bool retracting = false;

    Vector2 target;

    private void Start() {
        rope = GetComponent<LineRenderer>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0) && !isGrappling) {
            StartGrapple();
        }

        if (retracting) {
            Vector2 grapplePos = Vector2.Lerp(transform.position, target, grappableSpeed * Time.deltaTime);

            transform.position = grapplePos;

            rope.SetPosition(0, transform.position);

            if (Vector2.Distance( transform.position, target) < 2f) {
                retracting = false;
                isGrappling = false;
                rope.enabled = false;
            } 
        }
    }

    private void StartGrapple() {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance, grappableMask);

        if (hit.collider != null) {
            isGrappling = true;
            target = hit.point;
            rope.enabled = true;
            rope.positionCount = 2;

            StartCoroutine(Grapple());
        }
    }

    IEnumerator Grapple() {
        float t = 0;
        float time = 10;
        rope.SetPosition(0, transform.position);
        rope.SetPosition(1, transform.position);

        Vector2 newPos;

        for (; t < time; t += grappableShootSpeed * Time.deltaTime) {
            newPos = Vector2.Lerp(transform.position, target, t / time);
            rope.SetPosition(0, transform.position);
            rope.SetPosition(1, newPos);
            yield return null;
        }
        rope.SetPosition(1, target);
        retracting = true;
    }
}
