using System;
using System.Runtime.InteropServices;

namespace BundtEngine
{
    class Program
    {
		private const string DllFilePath = "BundtLowLevelEngine.dll";

		[DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
		private extern static int start(Fred[] vertices, UInt32 verticesSize, UInt16[] indices, UInt32 indicesSize, Fred[] colors, Vector2[] texCoords);

		static int Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			var vertices = new Fred[] {
				new Fred(-0.5f, -0.5f, 0.0f, 1f),
				new Fred(0.5f, -0.5f, 0.0f, 1f),
				new Fred(0.5f, 0.5f, 0.0f, 1f),
				new Fred(-0.5f, 0.5f, 0.0f, 1f)
			};

			var indices = new UInt16[] { 0, 1, 2, 2, 3, 0 };

			var colors = new Fred[] {
				Color.Red,
				Color.Green,
				Color.Blue,
				Color.Purple
			};

			var texCoords = new Vector2[] {
				new Vector2(0.0f, 0.0f),
				new Vector2(1.0f, 0.0f),
				new Vector2(1.0f, 1.0f),
				new Vector2(0.0f, 1.0f)
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

	struct Fred
	{
		float X;
		float Y;
		float Z;
		float W;

		public Fred(float x, float y, float z, float w)
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}
	}

	struct GameObject
	{
		public Fred[] Vertices;
		public UInt16[] Indices;
		public Fred[] Colors;
		public Vector2[] TexCoords;

		public GameObject(Fred[] vertices, UInt16[] indices, Fred[] colors, Vector2[] texCoords)
		{
			Vertices = vertices;
			Indices = indices;
			Colors = colors;
			TexCoords = texCoords;
		}
	}

	static class Color
	{
		public static Fred Red = new Fred(1f, 0f, 0f, 1f);
		public static Fred Green = new Fred(0f, 1f, 0f, 1f);
		public static Fred Blue = new Fred(0f, 0f, 1f, 1f);
		public static Fred Purple = new Fred(1f, 0f, 1f, 1f);
	}
}