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
public class SineWaveGenerator : WaveGeneratorBase
{
    /// <summary>
    /// Number of degrees to advance per second.
    /// </summary>
    [SerializeField]
    protected float degreesPerSecond = 180.0f;

    /// <summary>
    /// Number of degrees to phase shift.
    /// </summary>
    [SerializeField]
    protected float degreesPhaseShift = 0.0f;

    [SerializeField]
    protected float elapsedSeconds = 0.0f;

    /// <summary>
    /// Mathf.Sin() accepts radians only, so we convert degreesPerSecond to radians for runtime.
    /// </summary>
    private float radiansPerSecond;

    /// <summary>
    /// Mathf.Sin() accepts radians only, so we convert degreesPhaseShift to radians for runtime.
    /// </summary>
    private float radiansPhaseShift;

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
    /// Number of degrees of phase shift.
    /// </summary>
    public float DegreesPhaseShift
    {
        get
        {
            return degreesPhaseShift;
        }
        set
        {
            degreesPhaseShift = value;
            radiansPhaseShift = DegreesToRadians(degreesPhaseShift);
        }
    }

    /// <summary>
    /// The value of the sine wave for the current point in time.
    /// </summary>
    public override float Output
    {
        get
        {
            return amplitude * Mathf.Sin((elapsedSeconds * radiansPerSecond) + radiansPhaseShift);
        }
    }

    /// <summary>
    /// Start of game play.
    /// </summary>
    private void Start()
    {
        radiansPerSecond = DegreesToRadians(degreesPerSecond);
        radiansPhaseShift = DegreesToRadians(degreesPhaseShift);
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
}
