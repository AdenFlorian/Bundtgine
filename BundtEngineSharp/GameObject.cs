using System;
using System.Collections.Generic;
using System.Text;

namespace BundtEngine
{
    struct GameObject
    {
		public Vector3[] Vertices;
		public UInt32[] Indices;
		public Vector3[] Colors;
		public Vector2[] TexCoords;

		public GameObject(Vector3[] vertices, UInt32[] indices, Vector3[] colors, Vector2[] texCoords)
		{
			Vertices = vertices;
			Indices = indices;
			Colors = colors;
			TexCoords = texCoords;
		}
	}
}
