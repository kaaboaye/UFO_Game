using UnityEngine;  

public class Rotator : MonoBehaviour
 { 
    private void Update () 
    { 
        Vector3 Vect = new Vector3(0, 0, 45);
         transform.Rotate(Vect * Time.deltaTime); 
    }
 } 
