using System;
using System.Runtime.InteropServices;

namespace BundtEngine
{
    class Program
    {
		private const string DllFilePath = "BundtLowLevelEngine.dll";

		[DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
		private extern static int start(Vector3[] vertices, UInt32 verticesSize, UInt16[] indices, UInt32 indicesSize, Vector3[] colors, Vector2[] texCoords);

		static int Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			var vertices = new Vector3[] {
				new Vector3(-0.5f, -0.5f, 0.0f),
				new Vector3(0.5f, -0.5f, 0.0f),
				new Vector3(0.5f, 0.5f, 0.0f),
				new Vector3(-0.5f, 0.5f, 0.0f),
				new Vector3(-0.5f, -0.5f, -0.5f),
				new Vector3(0.5f, -0.5f, -0.5f),
				new Vector3(0.5f, 0.5f, -0.5f),
				new Vector3(-0.5f, 0.5f, -0.5f)
			};

			var indices = new UInt16[] {
				0, 1, 2, 2, 3, 0,
				4, 5, 6, 6, 7, 4
			};

			var colors = new Vector3[] {
				Color.Blue,
				Color.Purple,
				Color.Red,
				Color.Green,
				Color.Red,
				Color.Green,
				Color.Blue,
				Color.Purple
			};

			var texCoords = new Vector2[] {
				new Vector2(0.0f, 0.0f),
				new Vector2(1.0f, 0.0f),
				new Vector2(1.0f, 1.0f),
				new Vector2(0.0f, 1.0f),
				new Vector2(1.0f, 1.0f),
				new Vector2(0.0f, 1.0f),
				new Vector2(0.0f, 0.0f),
				new Vector2(1.0f, 0.0f)
			};

			var go = new GameObject(vertices, indices, colors, texCoords);

			return start(go.Vertices, (UInt32)go.Vertices.Length, go.Indices, (UInt32)go.Indices.Length, go.Colors, go.TexCoords);
		}
	}

	struct Vector2
	{
		float X;
		float Y;

		public Vector2(float x, float y)
		{
			X = x;
			Y = y;
		}
	}

	struct Vector3
	{
		float X;
		float Y;
		float Z;

		public Vector3(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}
	}

	struct GameObject
	{
		public Vector3[] Vertices;
		public UInt16[] Indices;
		public Vector3[] Colors;
		public Vector2[] TexCoords;

		public GameObject(Vector3[] vertices, UInt16[] indices, Vector3[] colors, Vector2[] texCoords)
		{
			Vertices = vertices;
			Indices = indices;
			Colors = colors;
			TexCoords = texCoords;
		}
	}

	static class Color
	{
		public static Vector3 Red = new Vector3(1f, 0f, 0f);
		public static Vector3 Green = new Vector3(0f, 1f, 0f);
		public static Vector3 Blue = new Vector3(0f, 0f, 1f);
		public static Vector3 Purple = new Vector3(1f, 0f, 1f);
	}
}