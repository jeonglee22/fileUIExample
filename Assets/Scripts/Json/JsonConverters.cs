using UnityEngine;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

public class ItemDataConverter : JsonConverter<ItemData>
{
    public override ItemData ReadJson(JsonReader reader, Type objectType, ItemData existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var id = reader.Value as string;
        return DataTableManger.ItemTable.Get(id);
    }

    public override void WriteJson(JsonWriter writer, ItemData value, JsonSerializer serializer)
    {
        writer.WriteValue(value.Id);
    }
}

public class Vector3Converter : JsonConverter<Vector3>
{
    public override Vector3 ReadJson(JsonReader reader, Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        Vector3 v = Vector3.zero;
        JObject jObj = JObject.Load(reader);
        v.x = (float)jObj["X"];
        v.y = (float)jObj["Y"];
        v.z = (float)jObj["Z"];
        return v;
    }

    public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
    {
		writer.WriteStartObject();
		writer.WritePropertyName("X");
        writer.WriteValue(value.x);
        writer.WritePropertyName("Y");
        writer.WriteValue(value.y);
        writer.WritePropertyName("Z");
        writer.WriteValue(value.z);
		writer.WriteEndObject();
	}
}

public class QuaternionConverter : JsonConverter<Quaternion>
{
	public override Quaternion ReadJson(JsonReader reader, Type objectType, Quaternion existingValue, bool hasExistingValue, JsonSerializer serializer)
	{
		Quaternion q = Quaternion.identity;
		JObject jObj = JObject.Load(reader);
		q.x = (float)jObj["X"];
		q.y = (float)jObj["Y"];
		q.z = (float)jObj["Z"];
        q.w = (float)jObj["W"];
		return q;
	}

	public override void WriteJson(JsonWriter writer, Quaternion value, JsonSerializer serializer)
	{
		writer.WriteStartObject();
		writer.WritePropertyName("X");
		writer.WriteValue(value.x);
		writer.WritePropertyName("Y");
		writer.WriteValue(value.y);
		writer.WritePropertyName("Z");
		writer.WriteValue(value.z);
		writer.WritePropertyName("W");
		writer.WriteValue(value.w);
		writer.WriteEndObject();
	}
}

public class ColorConverter : JsonConverter<Color>
{
	public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
	{
		Color c = new Color();
		JObject jObj = JObject.Load(reader);
		c.r = (int)jObj["R"];
		c.g = (int)jObj["G"];
		c.b = (int)jObj["B"];
		c.a = (int)jObj["A"];

		return c;
	}

	public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
	{
		writer.WriteStartObject();
		writer.WritePropertyName("R");
		writer.WriteValue(value.r);
		writer.WritePropertyName("G");
		writer.WriteValue(value.g);
		writer.WritePropertyName("B");
		writer.WriteValue(value.b);
		writer.WritePropertyName("A");
		writer.WriteValue(value.a);
		writer.WriteEndObject();
	}
}
