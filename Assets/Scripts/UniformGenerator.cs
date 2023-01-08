using UnityEngine;
using System;
public class UniformGenerator : MonoBehaviour
{
    private int average;
    private int count;
    System.Random rnd;
    public UniformGenerator(int average, int count)
    {
        this.average = average;
        this.count = count;
        rnd = new System.Random();
    }
    public int GenerateBernoulliTrials()
    {
        bool[] values = new bool[count];
        int sum = 0;
        for (int i = 0; i < count; i++)
        {
            values[i] = rnd.NextDouble() < (double)1 / average;
            sum += values[i] ? 1 : 0;
        }
        return sum;
    }
}
