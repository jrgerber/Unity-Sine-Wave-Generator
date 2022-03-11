using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWaveGenerator : WaveGeneratorBase
{
    [SerializeField]
    protected List<WaveGeneratorBase> waveGenerators;

    public override float Output
    {
        get
        {
            float result = 0.0f;

            foreach (WaveGeneratorBase waveGenerator in waveGenerators)
            {
                result += waveGenerator.Output;
            }

            return result;
        }
    }
}
