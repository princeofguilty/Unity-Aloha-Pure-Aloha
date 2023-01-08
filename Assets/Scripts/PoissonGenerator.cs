using UnityEngine;
using System;


public class PoissonGenerator : MonoBehaviour
{
    private UniformGenerator uniformGenerator;
    private int average;
    private int interval;
    public PoissonGenerator(int average, int interval)
    {
        this.average = average;
        this.interval = interval;
        uniformGenerator = new UniformGenerator(average, average * average);
    }
    public int[] GeneratePoissonExperiments()
    {
        int[] values = new int[average * interval];
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = uniformGenerator.GenerateBernoulliTrials();
        }
        return values;
    }
    public double CalculatePoisson(int k)
    {
        double factorial = 1;
        int count = k;
        while (count > 0)
        {
            factorial *= count;
            count--;
        }
        return Math.Pow(Math.E, -average) * Math.Pow(average, k) / factorial;
    }
    public double CalculatePoissonSimulation(int k)
    {
        double factorial = 1;
        int count = k;
        while (count > 0)
        {
            factorial *= count;
            count--;
        }
        return Math.Pow(Math.E, -(double)interval / average) * Math.Pow((double)interval / average, k) / factorial;
    }
    public double CalculateExpectedMean()
    {
        return average;
    }
    public double CalculateExpectedVariance()
    {
        return average;
    }
    public double CalculateExpectedStandardDeviation()
    {
        return Math.Sqrt(CalculateExpectedVariance());
    }
}