using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cycles the color of a <c>GameObject</c>.
/// </summary>
public class SineWaveColorCycler : SineWaveBase
{
    [SerializeField]
    private bool cycleRed = true;

    [SerializeField]
    private bool cycleGreen = true;

    [SerializeField]
    private bool cycleBlue = true;

    [SerializeField]
    private bool cycleAlpha = false;

    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    protected override void WaveUpdate(float waveOutput)
    {
        // waveOutput swings from -Amplitude to +Amplitude.  Color values are from 0 to 1.  Adjust the waveOutput value to fit within 0.0f to 1.0f.
        float amplitude = base.waveGenerator.Amplitude;
        float adjustedOutput = (waveOutput + amplitude) / (amplitude * 2);

        meshRenderer.material.color = new Color(
            cycleRed ? adjustedOutput : meshRenderer.material.color.r,
            cycleGreen ? adjustedOutput : meshRenderer.material.color.g,
            cycleBlue ? adjustedOutput : meshRenderer.material.color.b,
            cycleAlpha ? adjustedOutput : meshRenderer.material.color.a);
    }
}
