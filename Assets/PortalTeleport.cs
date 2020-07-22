using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{

    public Transform player;
    public Transform destination;
    public float rotationOffset = 0f;
    private bool playerIsOverlapping = false;

    void Update()
    {
        if(playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            //If true, player moved across portal
            if(dotProduct < 0f)
            {
                CharacterController cc = player.GetComponent<CharacterController>();
                cc.enabled = false;

                float rotationDiff = -Quaternion.Angle(transform.rotation, destination.rotation);
                rotationDiff += rotationOffset;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = destination.position + positionOffset;

                playerIsOverlapping = false;
                cc.enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
