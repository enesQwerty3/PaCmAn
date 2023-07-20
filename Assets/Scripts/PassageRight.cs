using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageRight : MonoBehaviour
{
    //[SerializeField] private Vector2 connection_left = Vector2.zero;
    [SerializeField] private GameObject Pacman;
    [SerializeField] private GameObject Connection_Left;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Pacman")
        {
            Debug.Log("Collision with pacman!");
            Pacman.transform.position = Connection_Left.transform.position;
        }
    }
}
