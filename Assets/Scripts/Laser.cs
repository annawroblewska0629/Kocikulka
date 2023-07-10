using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    [SerializeField] int maxReflections = 10;
    [SerializeField] float laserDistance = 100f;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Button button;
    [SerializeField] Lever lever;
    private bool laserIsOn = true;
    
    private void Awake()
    {
       //button = TryGetComponent<> 
    }

    private void Start()
    {
        if(button != null)
        {
            button.OnButtonPressed += Button_OnButtonPressed;
            button.OnButtonUnpressed += Button_OnButtonUnpressed;
        }
        if(lever != null)
        {
            lever.OnLeverOn += Lever_OnLeverOn;
            lever.OnLeverOff += Lever_OnLeverOff;
        }
    }

    private void Update()
    {
        if (laserIsOn)
        {
            lineRenderer.enabled = true;
            // Rzut promienia lasera
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, laserDistance))
            {
                if (hit.collider.tag == "Cat")
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }

                lineRenderer.positionCount = 1;
                lineRenderer.SetPosition(0, transform.position);
                ReflectLaser(hit, 1);
            }
            else
            {
                lineRenderer.positionCount = 0;
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    private void ReflectLaser(RaycastHit hit, int reflections)
    {
        // Sprawdzanie limitu odbiæ
        if (reflections > maxReflections)
            return;

        // Dodawanie pozycji do LineRenderera
        lineRenderer.positionCount += 1;
        lineRenderer.SetPosition(reflections, hit.point);

        // Sprawdzanie tagu trafionego obiektu
        if (hit.collider.tag == "Mirror")
        {
            // Wyliczanie kierunku odbicia
            Vector3 reflectedDirection = Vector3.Reflect(hit.point - transform.position, hit.normal);

            // Rzut promienia odbitego
            RaycastHit reflectedHit;
            if (Physics.Raycast(hit.point, reflectedDirection, out reflectedHit, laserDistance))
            {
                // Obs³uga kolejnego odbicia
                ReflectLaser(reflectedHit, reflections + 1);
            }
        }
        else
        {
            // Przerwij promieñ, jeœli nie trafiono lustrem
            Debug.Log("Promieñ zakoñczony");
        }
    }

    public void Button_OnButtonPressed(object sender, EventArgs e)
    {
        laserIsOn = false;
    }
    public void Button_OnButtonUnpressed(object sender, EventArgs e)
    {
        laserIsOn = true;
    }

    public void Lever_OnLeverOn(object sender, EventArgs e)
    {
        laserIsOn = false;
    }
    public void Lever_OnLeverOff(object sender, EventArgs e)
    {
        laserIsOn = true;
    }
}




