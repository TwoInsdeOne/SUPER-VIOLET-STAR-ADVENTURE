using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyPatrolChase : MonoBehaviour
{
    public AIPath aiPath;
    public AIDestinationSetter aiDSetter;
    public Transform liccaGFX;
    public Patrol patrol;
    public bool chaseMode;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Violet Star").transform;
        chaseMode = false;
        patrol.enabled = true;
        aiDSetter.enabled = false;
        aiDSetter.target = player;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            liccaGFX.localScale = new Vector3(-1f, 1f, 1f);
        }else if(aiPath.desiredVelocity.x <= 0.01f)
        {
            liccaGFX.localScale = new Vector3(1f, 1f, 1f);
        }

        
        
        if (chaseMode)
        {
            if (!CanReach(player.position))
            {
                chaseMode = false;
                patrol.enabled = true;
                aiDSetter.enabled = false;
            }
        } else
        {
            if (CanReach(player.position))
            {
                chaseMode = true;
                aiDSetter.enabled = true;
                patrol.enabled = false;
            }
        }
        
    }
    private bool CanReach(Vector3 point)
    {
        GraphNode node1 = AstarPath.active.GetNearest(transform.position).node;
        GraphNode node2 = AstarPath.active.GetNearest(point).node;
        return PathUtilities.IsPathPossible(node1, node2);
    }
}
