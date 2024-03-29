﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Properties
   static ConfigurationData configurationData;
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    public static float BallLifeTime
    {
        get { return configurationData.BallLifeTime; }
    }

    public static float MinSpwanSeconds
    {
        get { return configurationData.MinSpwanSeconds; }
    }

    public static float MaxSpwanSeconds
    {
        get { return configurationData.MaxSpwanSeconds; }
    }
    public static float NumOfBalls
    {
        get { return configurationData.NumOfBalls; }
    }
    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
         configurationData = new ConfigurationData();
    }
}
