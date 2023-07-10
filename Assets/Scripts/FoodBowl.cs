using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodBowl : MonoBehaviour
{
    [SerializeField] string sceneName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "Cat")
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
