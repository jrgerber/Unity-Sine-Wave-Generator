using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cycles the color of a <c>GameObject</c>.
/// </summary>
public class SineWaveColorCycler : MonoBehaviour
{
    [SerializeField]
    private WaveGeneratorBase redWaveGenerator;

    [SerializeField]
    private WaveGeneratorBase greenWaveGenerator;

    [SerializeField]
    private WaveGeneratorBase blueWaveGenerator;

    [SerializeField]
    private WaveGeneratorBase alphaWaveGenerator;

    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Color result = new Color();
        if (redWaveGenerator != null)
        {
            // Output swings from -Amplitude to +Amplitude.
            // Color values are from 0 to 1.
            // Adjust the waveOutput value to fit within 0.0f to 1.0f.
            float amplitude = redWaveGenerator.Amplitude;
            result.r = (redWaveGenerator.Output + amplitude) / (amplitude * 2);
        }
        else
        {
            result.r = meshRenderer.material.color.r;
        }

        if (greenWaveGenerator != null)
        {
            // Output swings from -Amplitude to +Amplitude.
            // Color values are from 0 to 1.
            // Adjust the waveOutput value to fit within 0.0f to 1.0f.
            float amplitude = greenWaveGenerator.Amplitude;
            result.r = (greenWaveGenerator.Output + amplitude) / (amplitude * 2);
        }
        else
        {
            result.g = meshRenderer.material.color.g;
        }

        if (blueWaveGenerator != null)
        {
            // Output swings from -Amplitude to +Amplitude.
            // Color values are from 0 to 1.
            // Adjust the waveOutput value to fit within 0.0f to 1.0f.
            float amplitude = blueWaveGenerator.Amplitude;
            result.b = (blueWaveGenerator.Output + amplitude) / (amplitude * 2);
        }
        else
        {
            result.b = meshRenderer.material.color.b;
        }

        if (alphaWaveGenerator != null)
        {
            // Output swings from -Amplitude to +Amplitude.
            // Color values are from 0 to 1.
            // Adjust the waveOutput value to fit within 0.0f to 1.0f.
            float amplitude = alphaWaveGenerator.Amplitude;
            result.a = (alphaWaveGenerator.Output + amplitude) / (amplitude * 2);
        }
        else
        {
            result.a = meshRenderer.material.color.a;
        }

        meshRenderer.material.color = result;
    }
}
