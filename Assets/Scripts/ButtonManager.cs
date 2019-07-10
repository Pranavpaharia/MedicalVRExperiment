using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    Transform canvasTransform;
    Image img;
    Dictionary<string, bool> buttonCheckList = new Dictionary<string, bool>();
    List<string> buttonNames = new List<string>();
    bool bDetector, bThermo, bSampler, bPump, bSolvent;
    public GameObject DetectorButton;
    public GameObject ThermoButton;
    public GameObject SamplerButton;
    public GameObject PumpButton;
    public GameObject SolventButton;
    Material mat_detector, mat_thermo, mat_pump, mat_reservoir, mat_sampler;

    void Start()
    {
        canvasTransform = GameObject.Find("Canvas").transform;

        mat_detector = Resources.Load<Material>("Mat_Detector") as Material;
        mat_thermo = Resources.Load<Material>("Mat_Thermo") as Material;
        mat_sampler = Resources.Load<Material>("Mat_Sampler") as Material;
        mat_pump = Resources.Load<Material>("Mat_Pump") as Material;
        mat_reservoir = Resources.Load<Material>("Mat_Reservoir") as Material;


        Debug.Log(canvasTransform);

        mat_detector.color = Color.white;
        mat_thermo.color = Color.white;
        mat_sampler.color = Color.white;
        mat_pump.color = Color.white;
        mat_reservoir.color  = Color.white; ;

        int totalchild = canvasTransform.childCount;

        for (int i = 0; i < totalchild; i++)
        {
            Transform t = canvasTransform.GetChild(i);
            if (i == 0 && t.GetComponent<Button>())
            {
                string str = t.name;
                bool b = true;
                buttonCheckList.Add(str, b);
                buttonNames.Add(str);
                return;
            }

            
            if (t.GetComponent<Button>())
            {
                string str = t.name;
                bool b = false;
                buttonCheckList.Add(str, b);
                buttonNames.Add(str);
            }
        }
    }

    void IsActivate(string str)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick(GameObject go)
    {
       // btn = go.GetComponent<Button>();
      //  var ColorBlock = btn.colors;

        if(buttonCheckList.ContainsKey(go.name))
        {
            bool bStatus = buttonCheckList[go.name];
            
            if(bStatus)
            {
          //      ColorBlock.normalColor = Color.green;
                
            }
            else
            {
          //      ColorBlock.normalColor = Color.red;
                
            }
         //   btn.colors = ColorBlock;
        }

        //Set Next Key True
        int index = 0;
        for(int i = 0;i<buttonNames.Count;i++)
        {
            if(buttonNames[i] == go.name)
            {
                index = i;
            }
        }

       // buttonCheckList
    }

    public void DetectorButtonClick(GameObject go)
    {
        img = go.GetComponent<Image>();
        
        if (!bDetector)
        {
            mat_detector.color = Color.green;
            bDetector = !bDetector;
            go.GetComponent<ButtonAction>().bActivated = true;
        }
        else
        {
            mat_detector.color = Color.white;
            bDetector = !bDetector;
            go.GetComponent<ButtonAction>().bActivated = false;
        }
    }

    public void ThermoButtonClick(GameObject go)
    {
        img = go.GetComponent<Image>();

        if (!DetectorButton.GetComponent<ButtonAction>().bActivated)
            return;


        if (!bThermo && DetectorButton.GetComponent<ButtonAction>().bActivated)
        {
            mat_thermo.color = Color.green;
            bThermo = !bThermo;
            go.GetComponent<ButtonAction>().bActivated = true;
        }
        else
        {
            mat_thermo.color = Color.white;
            bThermo = !bThermo;
            go.GetComponent<ButtonAction>().bActivated = false;
        }
    }

    public void SamplerButtonClick(GameObject go)
    {
        img = go.GetComponent<Image>();

        if (!DetectorButton.GetComponent<ButtonAction>().bActivated || !ThermoButton.GetComponent<ButtonAction>().bActivated)
            return;



        if (!bSampler && 
            DetectorButton.GetComponent<ButtonAction>().bActivated &&
            ThermoButton.GetComponent<ButtonAction>().bActivated)
        {
            mat_sampler.color = Color.green;
            bSampler = !bSampler;
            go.GetComponent<ButtonAction>().bActivated = true;
        }
        else
        {
            mat_sampler.color = Color.white;
            bSampler = !bSampler;
            go.GetComponent<ButtonAction>().bActivated = false;
        }
    }

    public void PumpButtonClick(GameObject go)
    {
        img = go.GetComponent<Image>();


        if (!DetectorButton.GetComponent<ButtonAction>().bActivated ||
            !ThermoButton.GetComponent<ButtonAction>().bActivated ||
            !SamplerButton.GetComponent<ButtonAction>().bActivated)
            return;


        if (!bPump &&
            DetectorButton.GetComponent<ButtonAction>().bActivated &&
            ThermoButton.GetComponent<ButtonAction>().bActivated &&
            SamplerButton.GetComponent<ButtonAction>().bActivated)
        {
            mat_pump.color = Color.green;
            bPump = !bPump;
            go.GetComponent<ButtonAction>().bActivated = true;
        }
        else
        {
            mat_pump.color = Color.white;
            bPump = !bPump;
            go.GetComponent<ButtonAction>().bActivated = false;
        }
    }

    public void SolventButtonClick(GameObject go)
    {
        img = go.GetComponent<Image>();

        if (!DetectorButton.GetComponent<ButtonAction>().bActivated ||
            !ThermoButton.GetComponent<ButtonAction>().bActivated ||
            !SamplerButton.GetComponent<ButtonAction>().bActivated ||
            !PumpButton.GetComponent<ButtonAction>().bActivated)
            return;



        if (!bSolvent &&
            DetectorButton.GetComponent<ButtonAction>().bActivated &&
            ThermoButton.GetComponent<ButtonAction>().bActivated &&
            SamplerButton.GetComponent<ButtonAction>().bActivated &&
            PumpButton.GetComponent<ButtonAction>().bActivated)
        {
            mat_reservoir.color = Color.green;
            bSolvent = !bSolvent;
            go.GetComponent<ButtonAction>().bActivated = true;
        }
        else
        {
            mat_reservoir.color = Color.white;
            bSolvent = !bSolvent;
            go.GetComponent<ButtonAction>().bActivated = false;
        }
    }




}
