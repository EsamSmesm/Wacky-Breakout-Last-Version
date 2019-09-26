using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 50;
    static float ballImpulseForce = 600;
    static float ballLifeTime = 10;
    static float minSpwanSeconds = 5;
    static float maxSpwanSeconds = 10;
    static float numOfBalls = 10;
    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    public float BallLifeTime
    {
        get { return ballLifeTime;}
    }

    public float MinSpwanSeconds
    {
        get { return minSpwanSeconds; }          
    }

    public float MaxSpwanSeconds
    {
        get { return maxSpwanSeconds; }
    }

    public float NumOfBalls
    {
        get { return numOfBalls; }
    }
    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null;
        try
        {
            input = File.OpenText (Path.Combine(Application.streamingAssetsPath,ConfigurationDataFileName));
            string names = input.ReadLine();
            string values = input.ReadLine();
            SetValues(values);
        }
        catch (Exception e)
        {

        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }

    }
    #endregion
    public void SetValues (string values)
    {
        string[] val = values.Split(',');

        paddleMoveUnitsPerSecond = float.Parse(val[0]);
        ballImpulseForce = float.Parse(val[1]);
        ballLifeTime = float.Parse(val[2]);
        minSpwanSeconds = float.Parse(val[3]);
        maxSpwanSeconds = float.Parse(val[4]);
        numOfBalls = float.Parse(val[5]);
    }
}
