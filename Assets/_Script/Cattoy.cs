using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cattoy : MonoBehaviour
{

    
    public Animator catAnimator;
    private Camera mainCamera; 
    private float Toyle;

    //CountdownTimer
    public float countdownDuration = 15f;
    private float timer;
    private bool countdownStarted = false;
    public GameObject progressBar;
    public GameObject progressBarUI1;
    public GameObject progressBarUI2;
    private float initialBarWidth;
    private float currentBarWidth;
    private float initialBarX;
   

  

    // Start is called before the first frame update
    void Start()
    {
      
        //toyLength
        Renderer renderer = GetComponent<Renderer>();
        float Toyle = renderer.bounds.size.x;
        mainCamera = Camera.main;

       
        //timersetup
        timer = countdownDuration;
        progressBar.SetActive(false);
        progressBarUI1.SetActive(false);
        progressBarUI2.SetActive(false);


        Renderer rendererBar = progressBar.GetComponent<Renderer>();
        initialBarWidth = rendererBar.bounds.size.x;
        //Debug.Log(initialBarWidth);
        Transform transformBar = progressBar.GetComponent<Transform>();
        initialBarX = transformBar.transform.position.x;
        // Debug.Log(initialBarX);
    }


    // Update is called once per frame
    void Update()
    {
        //toyLength
        Renderer renderer = GetComponent<Renderer>();
        float Toyle = renderer.bounds.size.x;
        
        //toyLength -> Cat animation change
        float CameraWid = mainCamera.orthographicSize * 2 * mainCamera.aspect;
        float Ratio = Toyle / CameraWid;
        catAnimator.SetFloat("ratio", Ratio);

        //Cat triger -> CountdownTimer
        if (Ratio > 0.6 && !countdownStarted)
        {
            countdownStarted = true;
            progressBarUI1.SetActive(true);
            progressBarUI2.SetActive(true);
        }

        if (countdownStarted && timer > 0)
        {
            //scale+
            timer -= Time.deltaTime;
            float progressRatio = 1f - timer / countdownDuration;
            //current transform
            Transform transformBar = progressBar.GetComponent<Transform>();
            currentBarWidth = progressRatio * initialBarWidth ;
            Vector3 currentBarPosition = transformBar.position;
            //change scale
            transformBar.localScale = new Vector2(0.04f * progressRatio, 0.04f); //scale 0.04
            //change position
            float newBarX = initialBarX - 0.5f * initialBarWidth + 0.5f * currentBarWidth;
            transformBar.position = new Vector3(newBarX, currentBarPosition.y, currentBarPosition.z);
            progressBar.SetActive(true);
            
        }
        else if (countdownStarted)
        {
            //cat big
            countdownStarted = false;
        }
    }
}






//void calculateLe(float newForce)
// { 

//newForce -> newLength


// }



//void Resize(float newLength)
//{
// Get the current scale of the toy
//Vector3 scale = ToyleTransform.localScale;

// Update the scale's x component (length) with the new value
//scale.x = newLength;

// Apply the updated scale to the toy
//ToyleTransform.localScale = scale;

//}