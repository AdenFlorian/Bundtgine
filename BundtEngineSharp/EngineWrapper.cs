using System;
using System.Runtime.InteropServices;

namespace BundtEngine
{
	class EngineWrapper
	{
		private const string DllFilePath = "BundtLowLevelEngine.dll";

		[DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
		private extern static int start(Vector3[] vertices, UInt32 verticesSize, UInt32[] indices, UInt32 indicesSize, Vector3[] colors, Vector2[] texCoords);

		public GameObject GameObject;

		public EngineWrapper(GameObject gameObject)
		{
			GameObject = gameObject;
		}

		public void Start()
		{
			var result = start(GameObject.Vertices, (UInt32)GameObject.Vertices.Length, GameObject.Indices, (UInt32)GameObject.Indices.Length, GameObject.Colors, GameObject.TexCoords);
		}
	}
}
