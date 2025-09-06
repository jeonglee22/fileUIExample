using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class SomeClass
{
    public Vector3 pos;
    public Quaternion rot;
    public Vector3 scale;
    public Color color;
}


public class JsonTest2 : MonoBehaviour
{
    public static readonly string fileName = "cube.json";
    public static string FileFullPath => Path.Combine(Application.persistentDataPath, fileName);

    public GameObject target;
    public GameObject parent;

    public int spawnCount = 10;

	JsonConverter[] converters =
		{
			new Vector3Converter(),
			new QuaternionConverter(),
			new ColorConverter(),
		};

    private List<SomeClass> objects = new List<SomeClass>();
    private int count = 0;

    private float spawnPosX = 10f;
    private float spawnPosY = 5f;
    private float spawnPosZ = 20f;
    private float scaleMin = 0.5f;
    private float scaleMax = 1.5f;


	public void Save()
    {
        var json = JsonConvert.SerializeObject(objects, Formatting.Indented ,converters);
        File.WriteAllText(FileFullPath, json);
    }

    public void Load()
    {
        var childs = parent.GetComponentsInChildren<Transform>();
		foreach (var child in childs)
		{
            if (child.gameObject == parent)
                continue;

            Destroy(child.gameObject);
		}

		var json = File.ReadAllText(FileFullPath);
        var objs = JsonConvert.DeserializeObject<List<SomeClass>>(json, converters);
        objects = new List<SomeClass>();
        count = objs.Count;
        foreach (var obj in objs)
        {
            SetCube(obj.pos, obj.rot, obj.scale, obj.color);
            objects.Add(obj);
        }
	}

    public void Random()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            var pos = new Vector3(
                UnityEngine.Random.Range(-spawnPosX,spawnPosX),
                UnityEngine.Random.Range(-spawnPosY,spawnPosY),
                UnityEngine.Random.Range(0,spawnPosZ));
            var rot = UnityEngine.Random.rotation;
            var scale = Vector3.one * UnityEngine.Random.Range(scaleMin,scaleMax);
            var color = new Color(
				UnityEngine.Random.Range(0f, 1f),
				UnityEngine.Random.Range(0f, 1f),
				UnityEngine.Random.Range(0f, 1f),
				1f);
            SetCube(pos, rot, scale, color);
			SomeClass obj = new SomeClass();
			obj.pos = pos;
            obj.rot = rot;
            obj.scale = scale;
            obj.color = color;
            objects.Add(obj);
		}

        count += spawnCount;
    }

    private GameObject SetCube(Vector3 pos, Quaternion rot, Vector3 scale, Color color)
    {
		var obj = Instantiate(target, parent.transform);
        obj.transform.localPosition = pos;
        obj.transform.localRotation = rot;
		obj.transform.localScale = scale;
        obj.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", color);

        return obj;
	}
}
