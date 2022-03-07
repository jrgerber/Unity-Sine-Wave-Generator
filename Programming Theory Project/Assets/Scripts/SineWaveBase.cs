using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract base class for creating specialized sinusoidal GameObject operations. 
/// </summary>
public abstract class SineWaveBase : MonoBehaviour
{
    [SerializeField]
    protected SineWaveGenerator waveGenerator;

    // Update is called once per frame
    void Update()
    {
        WaveUpdate(waveGenerator.Output);
    }

    /// <summary>
    /// In the child class WaveUpdate is implemented to perform the desired behavior with waveOutput.
    /// </summary>
    /// <param name="waveOutput">The output of the <c>SineWaveGenerator</c></param>
    protected abstract void WaveUpdate(float waveOutput);
}
