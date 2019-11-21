using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TerrainTool : EditorWindow
{
    [MenuItem("Tools/ 3D Terrain Generator")]
	public static void GetWindow()
	{
		GetWindow(typeof(TerrainTool));
	}
}