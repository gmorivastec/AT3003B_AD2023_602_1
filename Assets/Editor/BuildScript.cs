using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;


public class BuildScript 
{
    [MenuItem("Builds/Mis Builds")]
    public static void BuildLinux()
    {
        // establecemos parámetros que vamos a usar para la creación de 
        // nuestro binario
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/RevisionTarea2y3.unity" };
        buildPlayerOptions.locationPathName = "Builds/JuegoChido";
        buildPlayerOptions.target = BuildTarget.StandaloneLinux64;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport buildReport = BuildPipeline.BuildPlayer(buildPlayerOptions);

        if(buildReport.summary.result == BuildResult.Succeeded)
            Debug.Log("BUILD CREADO EXITOSAMENTE");

        if(buildReport.summary.result == BuildResult.Failed)
            Debug.Log("ALGO SALIÓ MAL :(");

        // como llamarlo desde terminal
        // https://docs.unity3d.com/Manual/EditorCommandLineArguments.html

        // /home/grivas/Unity/Hub/Editor/2022.3.13f1/Editor/Unity -quit -batchmode -projectPath /home/grivas/work/ITESM/AT3003B/UNITY_1 -executeMethod BuildScript.BuildLinux -logFile -
    }
}
