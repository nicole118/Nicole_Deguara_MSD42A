using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float ScrollingSpeed = 0.02f;
    
    //material texture
    Material myMaterial;
    
    //the actual movement
    Vector2 offSet;


    // Start is called before the first frame update
    void Start()
    {
        //get the material from the renderer component
        myMaterial = GetComponent<Renderer>().material;

        //will scroll at given speed
        offSet = new Vector2(0f, ScrollingSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        //move by offSet
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;

    }
}
