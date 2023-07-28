using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChase : GhostBehavior
{
    private Node node;
    [SerializeField] private Transform target;
    private Vector2 direction = Vector2.zero;

    private void OnDisable() 
    {
        ghost.scatter.Enable();
        Debug.Log("Scatter Enabled!");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Node" && enabled)
        {
            Node node = other.GetComponent<Node>();
            float minDistanceBetween = float.MaxValue;
            foreach(Vector2 avaliableDirection in node.avalibleDirections)
            {
                Vector3 newPosition = transform.position + new Vector3(avaliableDirection.x, avaliableDirection.y, 0f); //possible new position
                float distanceBetween = (target.position - newPosition).sqrMagnitude; //distance between pacman and ghost's new position
                if(distanceBetween < minDistanceBetween)    //check if direction is closer than others to pacman
                {
                    minDistanceBetween = distanceBetween;
                    direction = avaliableDirection;
                }    
            }
            ghost.GhostMovement.SetDirection(direction);
        }
    }
}
