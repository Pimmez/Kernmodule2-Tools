using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TerrainTool : EditorWindow
{
	/// <summary>
	/// Other Stuff
	/// </summary>
	private string terrainBaseName = "";
	private int objectID = 1;
	private GameObject objectToSpawn;
	private float objectScale;

	/// <summary>
	/// Terrain Stuff
	/// </summary>
	private int depth = 20;
	private int height = 256;
	private int width = 256;

	[MenuItem("Tools/ 3D Terrain Generator")]
	public static void GetWindow()
	{
		GetWindow(typeof(TerrainTool));
	}

	private void OnGUI()
	{
		GUILayout.Label("Spawn New Object", EditorStyles.boldLabel);

		terrainBaseName = EditorGUILayout.TextField("Base Name", terrainBaseName);
		objectID = EditorGUILayout.IntField("Object ID", objectID);
		objectScale = EditorGUILayout.FloatField("Terrain Scale", objectScale);
		objectToSpawn = EditorGUILayout.ObjectField("Prefab to Spawn", objectToSpawn, typeof(GameObject), false) as GameObject;



		if (GUILayout.Button("Generate Terrain"))
		{
			Debug.LogError("Code not implemented yet");
		}

		if (GUILayout.Button("Save as Prefab"))
		{
			Debug.LogError("Code not implemented yet");
		}
	}

	private TerrainData GenerateTerrain(TerrainData _terrainData)
	{
		_terrainData.size = new Vector3(width, depth, height);

		_terrainData.SetHeights(0, 0, GenerateHeights());

		return _terrainData;
	}

	private float[,] GenerateHeights()
	{
		float[,] heights = new float[width, height];
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				heights[x, y] = CalculateHeights(x, y);
			}
		}
		return heights;
	}

	private float CalculateHeights(int _x, int _y)
	{
		float xCoord = _x / width * objectScale;
		float yCoord = _y / height * objectScale;

		return Mathf.PerlinNoise(xCoord, yCoord);
	}

}