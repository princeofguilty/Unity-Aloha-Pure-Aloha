using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class click_me : MonoBehaviour
{

    public GameObject stationx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnMouseOver()
    {
        var x = stationx.GetComponent<station>();
        Debug.Log(x.name);
        if (Input.GetMouseButtonDown(0))
        {
            x.start = true;
        }
    }



}
