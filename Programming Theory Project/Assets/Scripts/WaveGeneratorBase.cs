using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates delta values for a wave defined by amplitude and degreesPerSecond.
/// </summary>
/// <example>
/// Usage: Retrieve WaveGeneratorBase.Output and use the value to control an aspect of a GameObject such as movement, color, etc.
/// </example>
public abstract class WaveGeneratorBase : MonoBehaviour
{
    /// <summary>
    /// Amplitude of the wave.
    /// </summary>
    /// <remarks>
    /// A value of 1.0f will generate outputs of -1.0f to 1.0f
    /// </remarks>
    [SerializeField]
    protected float amplitude = 1.0f;

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
                Debug.LogError("Amplitude must be positive values only.  Use degreesPhaseShift = 180 instead.");
            }
            else
            {
                amplitude = value;
            }
        }
    }

    /// <summary>
    /// The value of the wave for the current point in time.
    /// </summary>
    public abstract float Output { get; }

    /// <summary>
    /// Formula to convert degrees to radians.
    /// </summary>
    /// <param name="degrees">Degrees to convert</param>
    /// <returns>Radians</returns>
    protected static float DegreesToRadians(float degrees)
    {
        return degrees / 180.0f * Mathf.PI;
    }
}
