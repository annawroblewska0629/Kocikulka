using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] GameObject apartment;
    [SerializeField] float rotationSpeed;
    PlayerInputAction playerInputAction;
    PlayerControls playerControls;
    private bool canReload = true;
    // Start is called before the first frame update
    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.Player.Enable();
        playerInputAction.Player.Restart.performed += Restart;
        playerControls = GetComponent<PlayerControls>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationDirection = playerInputAction.Player.Rotation.ReadValue<Vector3>();
        apartment.transform.Rotate(rotationSpeed * rotationDirection * Time.deltaTime);
    }
    void Restart(InputAction.CallbackContext context)
    {
        //if (canReload)
        //{
           // canReload = false;
           // DontDestroyOnLoad(playerControls);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           // StartCoroutine(EnableReload());
       // }
        
    }

    IEnumerator EnableReload()
    {
        yield return new WaitForSeconds(1.0f); // OpóŸnienie w sekundach
        canReload = true;
    }
}
