using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splitter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bar")
        {
            var bar_enter = other.GetComponent<bar>();

            if (bar_enter.splitted == true) return;

            Transform t = bar_enter.transform;
            var new_bar = Instantiate(bar_enter);
            
            new_bar.splitted = true;
            bar_enter.splitted = true;

            if (new_bar.source == 'r' || new_bar.source == 'l')
            {
                new_bar.gameObject.transform.Rotate(new Vector3(0, 0, 90));
                new_bar.gameObject.transform.position = new Vector3(this.transform.position.x, new_bar.transform.position.y, new_bar.transform.position.z) ;
                new_bar.source = 't';
            }
            else
            {
                new_bar.gameObject.transform.Rotate(new Vector3(0, 0, 90));
                bar_enter.gameObject.transform.Rotate(new Vector3(0, 0, 90));
                bar_enter.gameObject.transform.position = new Vector3(bar_enter.transform.position.x, this.transform.position.y, bar_enter.transform.position.z);
                new_bar.gameObject.transform.position = new Vector3(new_bar.transform.position.x, this.transform.position.y, new_bar.transform.position.z);
                new_bar.source = 'l';
                bar_enter.source = 'r';
            }
        }
    }

}
