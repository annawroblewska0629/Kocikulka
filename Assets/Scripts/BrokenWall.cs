using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWall : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int damage;
    [SerializeField] Transform destroyedWallPrefab;
    [SerializeField] Material brokenWallMaterial;

    private MeshRenderer wallMeshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        wallMeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "Cat")
        {
            if(health > 0)
            {
                health -= damage;
                Material[] materials = wallMeshRenderer.materials;
                materials[1] = brokenWallMaterial;
                wallMeshRenderer.materials = materials;
            }
            else
            {
                Instantiate(destroyedWallPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

    }
}
