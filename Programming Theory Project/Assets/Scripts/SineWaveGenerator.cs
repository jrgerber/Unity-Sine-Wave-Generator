using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates delta values for a sine wave defined by amplitude and degreesPerSecond.
/// </summary>
/// <example>
/// Usage:
///     1. Give values for amplitude and degreesPerSecond
///     2. Retrieve SineWaveGenerator.Output and use the value to control an aspect of a GameObject such as movement, color, etc.
/// </example>
public class SineWaveGenerator : MonoBehaviour
{
    /// <summary>
    /// Amplitude of the sine wave.
    /// </summary>
    /// <remarks>
    /// A value of 1.0f will generate outputs of -1.0f to 1.0f
    /// </remarks>
    [SerializeField]
    private float amplitude = 1.0f;

    /// <summary>
    /// Number of degrees to advance per second.
    /// </summary>
    [SerializeField]
    private float degreesPerSecond = 180.0f;

    [SerializeField]
    private float elapsedSeconds = 0.0f;

    /// <summary>
    /// Mathf.Sin() accepts radians only, so we convert degreesPerSecond to radians for runtime.
    /// </summary>
    private float radiansPerSecond;

    /// <summary>
    /// Amplitude of the sine wave.
    /// </summary>
    public float Amplitude
    {
        get
        {
            return amplitude;
        }
        set
        {
            if (amplitude < 0)
            {
                Debug.LogError("Amplitude must be positive values only.  Use PhaseShiftDegrees = 180 instead.");
            }
            else
            {
                amplitude = value;
            }
        }
    }

    /// <summary>
    /// Number of degrees to advance per second.
    /// </summary>
    public float DegreesPerSecond
    {
        get
        {
            return degreesPerSecond;
        }
        set
        {
            degreesPerSecond = value;
            radiansPerSecond = DegreesToRadians(degreesPerSecond);
        }
    }

    /// <summary>
    /// The value of the sine wave for the current point in time.
    /// </summary>
    public float Output
    {
        get
        {
            return amplitude * Mathf.Sin(elapsedSeconds * radiansPerSecond);
        }
    }

    /// <summary>
    /// Start of game play.
    /// </summary>
    private void Start()
    {
        radiansPerSecond = DegreesToRadians(degreesPerSecond);
    }

    /// <summary>
    /// Advances elapsedSeconds by Time.deltaTime.
    /// </summary>
    private void FixedUpdate()
    {
        unchecked
        {
            elapsedSeconds += Time.deltaTime;
        }

    }

    /// <summary>
    /// Resets the elapsed seconds to 0.
    /// </summary>
    public void Reset()
    {
        elapsedSeconds = 0.0f;
    }

    /// <summary>
    /// Formula to convert degrees to radians.
    /// </summary>
    /// <param name="degrees">Degrees to convert</param>
    /// <returns>Radians</returns>
    private static float DegreesToRadians(float degrees)
    {
        return degrees / 180.0f * Mathf.PI;
    }
}
