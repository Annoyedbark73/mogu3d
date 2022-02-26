using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ragdoll : MonoBehaviour
{

    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
    
        rb = GetComponent<Rigidbody>();
    }

     public void EnableRagdoll()
    {
        rb.isKinematic = false;
        rb.detectCollisions = true;
        Debug.Log("Active");
    }

    public void DisableRagdoll()
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;
        Debug.Log("Inactive");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            EnableRagdoll();
            StartCoroutine(Timeout());  
        }

    }
    IEnumerator Timeout()
    {
        

        yield return new WaitForSeconds(5);
       
        DisableRagdoll();
        SceneManager.LoadSceneAsync("testmap");



    }

}
