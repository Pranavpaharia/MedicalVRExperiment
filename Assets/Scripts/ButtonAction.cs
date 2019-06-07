using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    // Start is called before the first frame update
    public bool bActivated = false;
    void Start()
    {
        if(gameObject.GetComponent<Button>())
        {
            bActivated = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
