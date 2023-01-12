using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugGUIExamples : MonoBehaviour
{
    public List<station> stations = new List<station>();
    private TextMeshPro efficiency;
    private float calculateEfficiency;
    /* * * *
     * 
     *   [DebugGUIGraph]
     *   Renders the variable in a graph on-screen. Attribute based graphs will updates every Update.
     *    Lets you optionally define:
     *        max, min  - The range of displayed values
     *        r, g, b   - The RGB color of the graph (0~1)
     *        group     - The order of the graph on screen. Graphs may be overlapped!
     *        autoScale - If true the graph will readjust min/max to fit the data
     *   
     *   [DebugGUIPrint]
     *    Draws the current variable continuously on-screen as 
     *    $"{GameObject name} {variable name}: {value}"
     *   
     *   For more control, these features can be accessed manually.
     *    DebugGUI.SetGraphProperties(key, ...) - Set the properties of the graph with the provided key
     *    DebugGUI.Graph(key, value)            - Push a value to the graph
     *    DebugGUI.LogPersistent(key, value)    - Print a persistent log entry on screen
     *    DebugGUI.Log(value)                   - Print a temporary log entry on screen
     *    
     *   See DebugGUI.cs for more info
     * 
     * * * */

    // Disable Field Unused warning
#pragma warning disable 0414

    float success_S_;
    float failure_S_;

    void Awake()
    {
        efficiency=GetComponentInChildren<TextMeshPro>();
        DebugGUI.SetGraphProperties("efficiency", "efficiency", 0, 1, 0, new Color(1, 1, 0), true);
        Invoke("update_graph", 1);
    }

    int x = 0;

    void Update()
    {
        
    }

    public void update_graph()
    {
        success_S_ = 0;
        failure_S_ = 0;

        foreach (station x in stations)
        {
            success_S_ += x.success_S_;
            failure_S_ += x.failure_S_;
        }

        calculateEfficiency = success_S_ / (success_S_ + failure_S_);

        efficiency.text = "efficiency: " + Mathf.Round(calculateEfficiency * 100) + '%';

        if (success_S_ + failure_S_ != 0)
            DebugGUI.Graph("efficiency", calculateEfficiency);
        Invoke("update_graph", 1);
    }

    void FixedUpdate()
    {

    }

    void OnDestroy()
    {

    }
}
