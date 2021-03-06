using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class RoadFactory : FactoryScenery
{
    public GameObject[] Prefabs;

    public int[] ProbabilityWeight;
    private double[] _rectifiedProbabilityWeight;

    public RoadFactory()
    {
    }

    public void Awake()
    {
        _rectifiedProbabilityWeight = new double[Prefabs.Length + 1];
        int i, sum = VoidProbabilityWeight;
        for (i = 0; i < ProbabilityWeight.Length; i++)
        {
            _rectifiedProbabilityWeight[i] = ProbabilityWeight[i];
            sum += ProbabilityWeight[i];
        }
        double cum = 0;
        for (i = 0; i < _rectifiedProbabilityWeight.Length; i++)
        {
            _rectifiedProbabilityWeight[i] /= sum;
            _rectifiedProbabilityWeight[i] += cum;
            cum = _rectifiedProbabilityWeight[i];
        }
    }

    protected override GameObject LocalInstantiate()
    {
        double rng = Random.value;
        for (int i = 0; i < Prefabs.Length; i++)
            if (_rectifiedProbabilityWeight[i] > rng)
                return Instantiate(Prefabs[i]);
        return null;
    }

    protected override void OnObjectDestroy(GameObject obj)
    {
    }
}

