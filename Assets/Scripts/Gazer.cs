using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Gazer : MonoBehaviour
{
    float Maxtime = 3.0f;
    float currentTime = 0;
    public bool bGaze = false;
    bool bFirstTime = false;
    Button button;
    Toggle toggle;
    Image buttonImage;
    Color buttonColor;
    AudioSource audiocomponent;
    string Objectname;
    bool bToggle = true;
    // Start is called before the first frame update
    void Start()
    {
        audiocomponent = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bGaze)
        {
            currentTime += Time.deltaTime;
            if(currentTime > Maxtime)
            {
                
                currentTime = 0;
                bGaze = false;
                Debug.Log("Hack");
                if(button)
                button.onClick.Invoke();

                if(buttonImage)
                {
                    buttonColor = buttonImage.color;
                    buttonImage.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, 0.2f);
                    audiocomponent.Play();
                    Invoke("ButtonColorToggled", 1.0f);
                }

                if(toggle)
                {
                    toggle.isOn = bToggle;
                    toggle.onValueChanged.Invoke(bToggle);
                    bToggle = !bToggle;
                    audiocomponent.Play();

                }

                
            }
        }
    }

    public void Reset()
    {
        bGaze = false;
        currentTime = 0;
    }

    void ButtonColorToggled()
    {
        if(Objectname == "SkipButton")
        {
            button.interactable = false;
            buttonImage.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, 0.0f);
        }
        else
        { 
            buttonImage.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, 1.0f);
        }
    }

    public void OnPointerEnter(GameObject go)
    {
        Objectname = go.name;
        button = go.GetComponent<Button>();
        toggle = go.GetComponent<Toggle>();
        buttonImage = go.GetComponent<Image>();
        if(button)
        {
            bFirstTime = true;
            bGaze = true;
        }

        if(toggle)
        {
            bFirstTime = true;
            bGaze = true;
        }
        
        
    }

    public void OnPointerExit(GameObject go)
    {
        bGaze = false;
        currentTime = 0;
    }
}
