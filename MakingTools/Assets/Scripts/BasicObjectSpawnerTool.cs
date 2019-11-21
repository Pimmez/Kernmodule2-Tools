using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BasicObjectSpawnerTool : EditorWindow
{
	private string objectBaseName = "";
	private int objectID = 1;
	private GameObject objectToSpawn;
	private float objectScale;
	private float spawnRadius = 5f;
	private List<GameObject> spawnedObjects = new List<GameObject>();

	[MenuItem("Tools/Basic Object Spawner")]
	public static void ShowWindow()
	{
		GetWindow(typeof(BasicObjectSpawnerTool)); //GetWindow is a method inherited from the EditorWindow class.
	}

	private void OnGUI()
	{
		GUILayout.Label("Spawn New Object", EditorStyles.boldLabel);

		objectBaseName = EditorGUILayout.TextField("Base Name", objectBaseName);
		objectID = EditorGUILayout.IntField("Object ID", objectID);
		objectScale = EditorGUILayout.FloatField("Object Scale", objectScale);
		spawnRadius = EditorGUILayout.FloatField("Object Radius", spawnRadius);
		objectToSpawn = EditorGUILayout.ObjectField("Prefab to Spawn", objectToSpawn, typeof(GameObject), false) as GameObject;

		if(GUILayout.Button("Spawn Object"))
		{
			SpawnObject();
		}

		if(GUILayout.Button("Clear All"))
		{
			ClearAllObjects();
		}
	}

	private void SpawnObject()
	{
		if(objectToSpawn == null)
		{
			Debug.LogError("Error: Please assign an object to be spawned.");
			return;
		}

		if(objectBaseName == string.Empty)
		{
			Debug.LogError("Error: Please enter a base name for the object.");
			return;
		}

		Vector2 _spawnCircle = Random.insideUnitCircle * spawnRadius;
		Vector3 _spawnPos = new Vector3(_spawnCircle.x, 0f, _spawnCircle.y);

		GameObject _newObject = Instantiate(objectToSpawn, _spawnPos, Quaternion.identity);
		_newObject.name = objectBaseName + objectID;
		_newObject.transform.localScale = Vector3.one * objectScale;

		spawnedObjects.Add(_newObject);
		Debug.Log("Total ojbects in the List: " + spawnedObjects.Count);

		objectID++;
	}

	private void ClearAllObjects()
	{
		foreach (GameObject _gameObject in spawnedObjects)
		{
			DestroyImmediate(_gameObject);
		}
		Debug.Log("Total Cleared: " + spawnedObjects.Count);
		spawnedObjects.Clear();
		objectID = 0;
	}
}