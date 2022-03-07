using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Oscillates the position of a <c>GameObject</c> along the selected Axes.
/// </summary>
public class SineWaveAxisOscillator : SineWaveBase
{
    [SerializeField]
    private bool oscillateAxisX = true;

    [SerializeField]
    private bool oscillateAxisY = true;

    [SerializeField]
    private bool oscillateAxisZ = true;

    protected override void WaveUpdate(float waveOutput)
    {
        transform.localPosition = new Vector3(oscillateAxisX ? waveOutput : 0.0f, oscillateAxisY ? waveOutput : 0.0f, oscillateAxisZ ? waveOutput : 0.0f);
    }
}
