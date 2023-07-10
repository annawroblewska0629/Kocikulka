using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boundary : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Cat")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
            Destroy(collision.gameObject);
    }
}
