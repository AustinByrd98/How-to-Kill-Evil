using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionZone : MonoBehaviour
{
    public List<Collider2D> detections = new List<Collider2D>();
    Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        detections.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detections.Remove(collision);
    }

}
