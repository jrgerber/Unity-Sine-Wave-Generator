using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Oscillates the size of a <c>GameObject</c>.
/// </summary>
public class SineWaveSizeOscillator : SineWaveBase
{
    [SerializeField]
    private float minimumSize = 0;

    [SerializeField]
    private float maximumSize = 1;

    [SerializeField]
    private bool oscillateAxisX = true;

    [SerializeField]
    private bool oscillateAxisY = true;

    [SerializeField]
    private bool oscillateAxisZ = true;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        
    }

    protected override void WaveUpdate(float waveOutput)
    {
        // The waveOutput domain swings from -Amplitude to +Amplitude.  Size range values are from minimumSize to maximumSize.
        // Adjust the waveOutput domain to fit the size range.
        float amplitude = base.waveGenerator.Amplitude;
        float adjustedOutput = (waveOutput + amplitude) * (maximumSize - minimumSize) / (amplitude * 2) + minimumSize;

        transform.localScale = new Vector3(
            oscillateAxisX ? adjustedOutput : transform.localScale.x,
            oscillateAxisY ? adjustedOutput : transform.localScale.y,
            oscillateAxisZ ? adjustedOutput : transform.localScale.z);
    }
}
